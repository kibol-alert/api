using Kibol_Alert.Models;

namespace Kibol_Alert.ViewModels
{
    public class ClubRelationVM
    {
        public int ClubId { get; set; }
        public string ClubName { get; set; }
        public RelationType Relation { get; set; }
    }
}
