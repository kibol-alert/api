using System;

namespace Kibol_Alert.Responses.Wrappers.Attributes
{
    internal sealed class LocalizedAttribute : Attribute
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }

        public LocalizedAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }  
    }
}
