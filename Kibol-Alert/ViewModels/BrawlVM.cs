using Kibol_Alert.Models;
using System;

namespace Kibol_Alert.ViewModels
{
    public class BrawlVM
    {
        public int Id { get; set; }
        public ClubVM FirstClub { get; set; }
        public int FirstClubId { get; set; }
        public ClubVM SecondClub { get; set; }
        public int SecondClubId { get; set; }
        public DateTime Date { get; set; }
        public Location Location { get; set; }
    }
}
