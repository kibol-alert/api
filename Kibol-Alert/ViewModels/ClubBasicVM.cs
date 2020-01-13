using Kibol_Alert.Models;
using System.Collections.Generic;

namespace Kibol_Alert.ViewModels
{
    public class ClubBasicVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string League { get; set; }
        public string LogoUri { get; set; }
        public string City { get; set; }
        public bool IsDeleted { get; set; }
    }
}
