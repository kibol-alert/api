using Kibol_Alert.Models;

namespace Kibol_Alert.Requests
{
    public class ClubRequest
    {
        public string Name { get; set; }
        public string League { get; set; }
        public string LogoUri { get; set; }
        public float? Longitude { get; set; }
        public float? Latitude { get; set; }
    }
}