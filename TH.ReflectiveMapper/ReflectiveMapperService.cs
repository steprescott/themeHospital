using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TH.ReflectiveMapper
{
    /// <summary>
    /// Service for mapping between two different objects, i.e. Database objects and Domain objects
    /// </summary>
    public static class ReflectiveMapperService
    {
        private class StackOverflowCheck
        {
            public Type Type { get; set; }
            public int Counter { get; set; }

            public StackOverflowCheck(Type type)
            {
                Type = type;
                Counter = 0;
            }
        }

        private static List<StackOverflowCheck> recursiveStackOverflowChecks = new List<StackOverflowCheck>();

        /// <summary>
        /// Converts objects from a source type to a destination type
        /// </summary>
        /// <typeparam name="TSource">The type to convert from</typeparam>
        /// <typeparam name="TDestination">The type to convert to</typeparam>
        /// <param name="source">An instantiated object in which to convert from</param>
        /// <returns>The result of the conversion</returns>
        public static TDestination ConvertItem<TSource, TDestination>(TSource source) 
            where TSource : class 
            where TDestination : class
        {
            if (source == null || recursiveStackOverflowChecks.Any(soc => soc.Counter > 5))
            {
                //return null;
            }

            //Get an instance of the destination object
            var destination = GenerateInstanceFromDestinationSource<TDestination>();

            //Ensure if there are lists being carried through then ensure source and destination are
            if ((source.IsCollection() && !destination.IsCollection() || (!source.IsCollection() && destination.IsCollection())))
            {
                throw new Exception("Cannot convert a list type to a none list type");
            }

            //Otherwise proceed with main code
            if (source.IsCollection() && destination.IsCollection())
            {
                //Now we know the types are lists, create a instance of that list to add to
                dynamic destinationList = destination;

                //Cast the source list
                dynamic sourceList = source;

                //Iterate though each item, all collections inherit off of an enumerator so should be able to foreach through them
                foreach (var item in sourceList)
                {
                    //Get each type for source and destination
                    Type destinationListSingleType = destinationList.GetType().GetGenericArguments()[0];
                    Type sourceListSingleType = sourceList.GetType().GetGenericArguments()[0];

                    //Invoke the method passing through the object we are converting from
                    var result = InvokeGenericMethodRecursion(sourceListSingleType, destinationListSingleType, item);

                    //Add the item into the list we created for the destination items
                    destinationList.Add(result);
                }

                //Return the list made
                return (TDestination) destinationList;
            }

            //Get the properties of the source and the destination
            var sourceProperties = source.GetType().GetProperties();
            var destinationProperties = destination.GetType().GetProperties();

            //Iterate through all the source properties setting them on the destination object if possible
            foreach (var sourceProperty in sourceProperties)
            {
                //Determine if there is a matching property to copy to
                var matchedDestinationProperty = destinationProperties.GetPropertyInfoIfPossible(sourceProperty.Name);

                //Get the property out of the source value
                var sourcePropertyValue = sourceProperty.GetValue(source, null);

                //If the type is nullable then don't bother setting it
                //If its not null the result of GetUnderlyingType then that means that it is nullable
                if (Nullable.GetUnderlyingType(sourceProperty.GetType()) == null && (matchedDestinationProperty != null && Nullable.GetUnderlyingType(matchedDestinationProperty.GetType()) == null))
                { 
                    //If there is one then set it, otherwise just fall through without setting
                    if (source.PropertyAndValueIsValid(sourceProperty, matchedDestinationProperty))
                    {
                        //Determine if system type
                        var sourceTypeIsSystemType = Type.GetType(matchedDestinationProperty.PropertyType.FullName);

                        //Get the setter of the destination property
                        var setMethod = matchedDestinationProperty.GetSetMethod();

                        //If the type is a system type, just map it directly
                        if (sourceTypeIsSystemType != null)
                        {
                            if (sourcePropertyValue.IsCollection())
                            {
                                //Call recursively to get the result
                                var list = InvokeGenericMethodRecursion(sourcePropertyValue.GetType(), matchedDestinationProperty.PropertyType, sourcePropertyValue);

                                //Invoke the method passing through the object we are converting from
                                sourcePropertyValue = list;
                            }

                            //Set the destination to the value of the source
                            setMethod.Invoke(destination, new[] { sourcePropertyValue });
                        }
                        else
                        {
                            //Get an instance of what the object we are converted from should become
                            var subDestintationProperty = Activator.CreateInstance(matchedDestinationProperty.PropertyType);

                            //Call recursively to get the result
                            var genericRecursionResult = InvokeGenericMethodRecursion(sourcePropertyValue.GetType(), subDestintationProperty.GetType(), sourcePropertyValue);

                            //Set the destination to the value of the source
                            setMethod.Invoke(destination, new[] { genericRecursionResult });
                        }
                    }
                }
            }

            //Return the final object
            return (TDestination) destination;
        }

        /// <summary>
        /// Generates an instance of an object from the passed through class
        /// </summary>
        /// <typeparam name="TDestination">The object we will be generating an instance for</typeparam>
        /// <returns>An instantiated object</returns>
        private static object GenerateInstanceFromDestinationSource<TDestination>()
        {
            //A dynamic object which we will use to be able to configure interface collections if there is any
            dynamic dynamicDestination;

            //First of all determine if the destination is an interface
            //If not carry on as usual
            if (typeof(TDestination).IsAbstract)
            {
                //First, get what the is collection is made up of
                Type singularListType = typeof(TDestination).GetGenericArguments().Single();

                //Now get a generic list with no type assigned to it
                Type listGenericType = typeof(List<>);

                //Now get a list of the singular type we have just determined
                Type list = listGenericType.MakeGenericType(singularListType);

                //Get the constructor info for the list we are creating so we can invoke it
                ConstructorInfo constructorInfo = list.GetConstructor(new Type[] { });

                //Set the dynamic destination to the list type of the singular object instance
                dynamicDestination = constructorInfo.Invoke(new object[] { });
            }
            else
            {
                //Just create an instance of the TDestination, there is nothing interface related going off here
                dynamicDestination = Activator.CreateInstance<TDestination>();
            }

            //Make an instance of the class that we can use that was generated from the above code
            return (object)dynamicDestination;
        }

        /// <summary>
        /// Invokes the convert item as appropriate for a property value
        /// </summary>
        /// <param name="sourceType">The type we are converting from</param>
        /// <param name="destinationType">The type we are converting to</param>
        /// <param name="sourcePropertyValue">The value of the source</param>
        /// <returns>The converted destination object</returns>
        private static object InvokeGenericMethodRecursion(Type sourceType, Type destinationType, object sourcePropertyValue)
        {
            //Get the method info for the recursion to take place
            MethodInfo method = typeof(ReflectiveMapperService).GetMethod("ConvertItem");

            //Generate the Generic parameters
            MethodInfo generic = method.MakeGenericMethod(sourceType, destinationType);

            //var test = recursiveStackOverflowChecks.SingleOrDefault(soc => soc.Type == sourceType);
            //if (test == null)
            //{
            //    recursiveStackOverflowChecks.Add(new StackOverflowCheck(sourceType));
            //}
            //else
            //{
            //    recursiveStackOverflowChecks.Remove(test);
            //    test.Counter = test.Counter++;
            //    recursiveStackOverflowChecks.Add(test);
            //}

            //Invoke the method passing through the object we are converting from
            return generic.Invoke(null, new[] { sourcePropertyValue });
        }

        //private static IEnumerable<PropertyInfo> RecursivelyGetProperties(object sourcePropertyValue)
        //{
        //    var properties = sourcePropertyValue.GetType().GetProperties();

        //    foreach (var propertyInfo in properties)
        //    {
        //        object propValue = propertyInfo.GetValue(sourcePropertyValue, null);
        //        if (propertyInfo.PropertyType.Assembly == sourcePropertyValue.GetType().Assembly)
        //        {
        //            yield return RecursivelyGetProperties(propValue).AsEnumerable();
        //        }
        //        return 
        //    }
        //}

        /// <summary>
        /// Gets a property by name if it exists in a array of property info's
        /// </summary>
        /// <param name="propertyInfos">Array of property values</param>
        /// <param name="searchName">The property to search for</param>
        /// <returns></returns>
        private static PropertyInfo GetPropertyInfoIfPossible(this PropertyInfo[] propertyInfos, string searchName)
        {
            return propertyInfos.SingleOrDefault(dp => string.Equals(dp.Name, searchName, StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// Validates a property exists, if types between source and destination match and if the value is not null
        /// </summary>
        /// <param name="source">The source object being validated</param>
        /// <param name="sourcePropertyInfo">The source property info</param>
        /// <param name="destinationPropertyInfo">The destination property info</param>
        /// <returns>A Boolean indicating validity</returns>
        private static bool PropertyAndValueIsValid(this object source, PropertyInfo sourcePropertyInfo, PropertyInfo destinationPropertyInfo)
        {
            //Get the property out of the source value
            var sourcePropertyValue = sourcePropertyInfo.GetValue(source, null);

            //Determine if its valid
            return destinationPropertyInfo != null && sourcePropertyInfo.GetType() == destinationPropertyInfo.GetType() && sourcePropertyValue != null;
        }

        /// <summary>
        /// Function for determined if an object is a list type
        /// </summary>
        /// <param name="potentialListObject">The object to be checked</param>
        /// <returns>A Boolean indicating if the object is of type list</returns>
        private static bool IsCollection(this object potentialListObject)
        {
            //Get the type of the object
            var originalType = potentialListObject.GetType();

            //Determine if the type os of type collection or enumerable
            var collectionType = Array.Exists(originalType.GetInterfaces(), IsGenericCollectionType);
            var enumerableType = Array.Exists(originalType.GetInterfaces(), IsGenericEnumerableType);

            //Technically a string is a collection so ensure the object isn't a string
            return (collectionType || enumerableType) && !(potentialListObject is string);
        }

        /// <summary>
        /// Determine if type is of type Collection
        /// </summary>
        /// <param name="type">The type we are checking</param>
        /// <returns>Boolean indicating if the type is of collection</returns>
        private static bool IsGenericCollectionType(Type type)
        {
            return type.IsGenericType && (typeof(ICollection<>) == type.GetGenericTypeDefinition());
        }

        /// <summary>
        /// Determine if type is of type Enumerable
        /// </summary>
        /// <param name="type">The type we are checking</param>
        /// <returns>Boolean indicating if the type is of enumerable</returns>
        private static bool IsGenericEnumerableType(Type type)
        {
            return type.IsGenericType && (typeof(IEnumerable<>) == type.GetGenericTypeDefinition());
        }
    }
}
