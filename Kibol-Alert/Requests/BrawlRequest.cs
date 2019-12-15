using Kibol_Alert.Models;
using System;

namespace Kibol_Alert.Requests
{
    public class BrawlRequest
    {
        public int FirstClubId { get; set; }
        public int SecondClubId { get; set; }
        public DateTime Date { get; set; }
        public Location Location { get; set; }
    }
}
