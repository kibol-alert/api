namespace Kibol_Alert.Models
{
    public class Location
    {
        public Location(float Latitude, float Longitude)
        {
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }
        public int Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
