using System;
using System.Collections.Generic;
using System.Text;

namespace POD.Models
{
    public class UserPreferences
    {
        public UserPreferences()
        {
            MaxDeviationInMinutes = 15;
            MaxWalkDistanceInMeters = 100;
        }

        public Guid UserId { get; set; }
        public LocationData Destination { get; set; }
        public LocationData StartLocation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MaxDeviationInMinutes { get; set; } // Default 15 min
        public int MaxWalkDistanceInMeters { get; set; } // Default 100 m
    }
}
