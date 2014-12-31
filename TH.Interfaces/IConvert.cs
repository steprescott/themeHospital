using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Interfaces
{
    public interface IConvert 
    {
        TDestination ConvertToEntityFramework<TSource, TDestination>(TSource source) where TDestination : class;
        TDestination ConvertToDomain<TSource, TDestination>(TSource source) where TDestination : class;
    }
}
