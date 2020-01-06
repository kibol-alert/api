using Kibol_Alert.Models;
using System;

namespace Kibol_Alert.ViewModels
{
    public class BrawlVM
    {
        public int Id { get; set; }
        public string FirstClubName { get; set; }
        public string SecondClubName { get; set; }
        public string Date { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}
