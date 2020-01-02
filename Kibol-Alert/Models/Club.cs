using System.Collections.Generic;

namespace Kibol_Alert.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string League { get; set; }
        public string City { get; set; }
        public string LogoUri { get; set; }
        public ICollection<ClubRelation> RelationsWith { get; set;}
        public ICollection<ClubRelation> InRelationsWith { get; set; }
        public ICollection<User> Fans { get; set; }
        public ICollection<Chant> Chants { get; set; }
        public float? Longitude { get; set; }
        public float? Latitude { get; set; }
        public bool IsDeleted { get; set; }
    }
}