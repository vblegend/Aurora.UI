﻿
namespace Aurora.UI.Xaml.Converters
{


    [XamlConverter(typeof(Object))]
    internal class ObjectConverter : IXamlPropertyConverter
    {
        public Object Convert(Type propertyType, string value)
        {
            return value;
        }
    }
}
