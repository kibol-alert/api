using Kibol_Alert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.ViewModels
{
    public class ClubVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string League { get; set; }
        public string LogoUri { get; set; }
        public virtual ICollection<ClubRelation> ClubRelations { get; set; }
        public virtual ICollection<UserVM> Fans { get; set; }
        public bool IsDeleted { get; set; }
    }
}
