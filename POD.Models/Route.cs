using System;
using System.Collections.Generic;
using System.Text;

namespace POD.Models
{
    public class Route
    {
        public LocationData Destination { get; set; }
        public LocationData StartLocation { get; set; }
        public List<LocationData> WayPoints { get; set; }
    }
}
