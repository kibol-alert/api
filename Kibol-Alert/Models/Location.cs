using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Models
{
    public class Location
    {
        public int Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public ICollection<Brawl> Brawls { get; set; }
    }
}
