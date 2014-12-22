using System;
using System.Collections;
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
            //Make an instance of the class we are converting to
            var destination = Activator.CreateInstance<TDestination>();

            //Ensure if there are lists being carried through then ensure source and destination are
            if ((source.IsList() && !destination.IsList() || (!source.IsList() && destination.IsList())))
            {
                throw new Exception("Cannot convert a list type to a none list type");
            }

            //Otherwise proceed with main code
            if (source.IsList() && destination.IsList())
            {
                //Now we know the types are lists, create a instance of that list to add to
                var destinationType = typeof(TDestination);
                var destinationList = Activator.CreateInstance(destinationType);

                //Cast the source list
                var sourceList = (IList) source;

                //Iterate though each item
                foreach (var item in sourceList)
                {
                    //Get each type for source and destination
                    Type destinationListSingleType = destinationList.GetType().GetGenericArguments().Single();
                    Type sourceListSingleType = sourceList.GetType().GetGenericArguments().Single();

                    //Invoke the method passing through the object we are converting from
                    var result = InvokeGenericMethodRecursion(sourceListSingleType, destinationListSingleType, item);

                    //Add the item into the list we created for the destination items
                    ((IList)destinationList).Add(result);
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
                        if (sourcePropertyValue.IsList())
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

            //Return the final object
            return destination;
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

            //Invoke the method passing through the object we are converting from
            return generic.Invoke(null, new[] { sourcePropertyValue });
        }

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
        private static bool IsList(this object potentialListObject)
        {
            var originalType = potentialListObject.GetType();
            return originalType.IsGenericType && originalType.GetGenericTypeDefinition() == typeof(List<>);
        }
    }
}
