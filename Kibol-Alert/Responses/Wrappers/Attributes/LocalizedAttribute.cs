using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
