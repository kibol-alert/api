using System.Collections.Generic;
using Kibol_Alert.Models;



namespace Kibol_Alert.ViewModels
{
    public class ClubVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string League { get; set; }
        public string LogoUri { get; set; }
        public virtual ICollection<ClubRelationVM> ClubRelations { get; set; }
        public virtual ICollection<MemberVM> Fans { get; set; }
        public bool IsDeleted { get; set; }
    }
}
