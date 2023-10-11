using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectConversion
{
    public class CustomMapper : ICustomMapper
    {
        public TDestination MapObject<TSource, TDestination>(TSource source, Action<TDestination>? customMap = null) where TDestination : class, new()
        {
            var destinationObject = new TDestination();

            var propertiesList = destinationObject.GetType().GetProperties();

            if (customMap != null)
            {
                customMap(destinationObject);
            }
            else
            {
                foreach (var prop in propertiesList)
                {
                    var value = source.GetType().GetProperty(prop.Name)?.GetValue(source);
                    prop.SetValue(destinationObject, value, null);
                }
            }

            return destinationObject;
        }

        public List<TDestination> MapObjects<TSource, TDestination>(List<TSource> sourceObj, Action<TDestination>? customMap = null) where TDestination : class, new()
        {
            var destinationList = new List<TDestination>();

            foreach (TSource sourceElement in sourceObj)
            {
                TDestination destinationElement = MapObject<TSource, TDestination>(sourceElement);
                destinationList.Add(destinationElement);
            }

            return destinationList;
        }
    }
}
