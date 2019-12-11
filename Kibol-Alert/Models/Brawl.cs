using System;

namespace Kibol_Alert.Models
{
    public class Brawl
    {
        public int Id { get; set; }
        public Club FirstClub { get; set; }
        public Club SecondClub { get; set; }
        public DateTime Date { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
