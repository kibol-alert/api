using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string League { get; set; }
        public string LogoUri { get; set; }
        public virtual ICollection<ClubRelation> ClubRelations {get; set;}
        public virtual ICollection<User> Fans { get; set; }
        public bool IsDeleted { get; set; }
    }
}
