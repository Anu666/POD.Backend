using System;
using System.Collections.Generic;
using System.Text;

namespace POD.Models
{
    public class Ride
    {
        public Guid Id { get; set; }
        public CaptainInformation CaptainInfo { get; set; }
        public Guid SharedGroupId { get; set; }
        public DateTime UpdateLocationDate { get; set; }
        public int MaxPassengers {get; set;}
        public bool IsRideFull { get; set; }
        public bool IsActive { get; set; }
        public bool IsStarted { get; set; }
        public bool IsEnded { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ProbabaleEndTime { get; set; }
        public Route RideRoute { get; set; }
    }
}
