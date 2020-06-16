namespace POD.StaticData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using GeoCoordinatePortable;

    using POD.Models;

    public class RideData
    {
        #region Data
        private static List<Ride> Rides = new List<Ride>()
            {
                new Ride()
                {
                    Id = new Guid("9f3909ed-d2cb-4cbd-9763-9b43807605ab"),
                    CaptainInfo = new CaptainInformation()
                    {
                        Name = "Sahitha",
                        Image = "",
                        LastKnownLocation = new LocationData()
                        {
                            Latitude = 17.4401,
                            Longitude = 78.3489,
                            Description = "GachiBowli",
                        }
                    },
                    SharedGroupId = new Guid("46da8f83-610e-47c9-a5f7-a666c6dea646"),
                    UpdateLocationDate = new DateTime(2020, 6, 14),
                    IsActive = true,
                    IsEnded = false,
                    IsStarted = false,
                    StartTime = new DateTime(2020, 6, 14, 9, 0, 0),
                    ProbabaleEndTime = new DateTime(2020, 6, 14, 10, 0, 0),
                    RideRoute = new Route()
                    {
                        Destination = new LocationData()
                        {
                            Latitude = 17.404563,
                            Longitude = 78.330833,
                            Description = "GGK Technologies Kokapet, Hyderabad, Telangana 500075"
                        },
                        StartLocation = new LocationData()
                        {
                            Latitude = 17.4401,
                            Longitude = 78.3489,
                            Description = "GachiBowli",
                        },
                        WayPoints = new List<LocationData>()
                        {
                            new LocationData()
                            {
                                Latitude = 17.4401,
                                Longitude = 78.3489,
                                Description = "GachiBowli",
                            },
                            new LocationData()
                            {
                                Latitude = 17.404563,
                                Longitude = 78.330833,
                                Description = "GGK Technologies Kokapet, Hyderabad, Telangana 500075"
                            }
                        }
                    }
                },
                new Ride()
                {
                    Id = new Guid("9db9f888-d45d-47bd-aadf-9c3cc0ce4e4d"),
                    CaptainInfo = new CaptainInformation()
                    {
                        Name = "Aditya",
                        Image = "",
                        LastKnownLocation = new LocationData()
                        {
                            Latitude = 17.4401,
                            Longitude = 78.3489,
                            Description = "GachiBowli",
                        }
                    },
                    UpdateLocationDate = new DateTime(2020, 6, 14),
                    IsActive = true,
                    IsEnded = false,
                    IsStarted = false,
                    StartTime = new DateTime(2020, 6, 14, 9, 15, 0),
                    ProbabaleEndTime = new DateTime(2020, 6, 14, 10, 30, 0),
                    RideRoute = new Route()
                    {
                        Destination = new LocationData()
                        {
                            Latitude = 17.404563,
                            Longitude = 78.330833,
                            Description = "GGK Technologies Kokapet, Hyderabad, Telangana 500075"
                        },
                        StartLocation = new LocationData()
                        {
                            Latitude = 17.4401,
                            Longitude = 78.3489,
                            Description = "GachiBowli",
                        },
                        WayPoints = new List<LocationData>()
                        {
                            new LocationData()
                            {
                                Latitude = 17.4401,
                                Longitude = 78.3489,
                                Description = "GachiBowli",
                            },
                            new LocationData()
                            {
                                Latitude = 17.404563,
                                Longitude = 78.330833,
                                Description = "GGK Technologies Kokapet, Hyderabad, Telangana 500075"
                            }
                        }
                    }
                }
            };

        #endregion

        public static List<Ride> GetAllRides()
        {
            return Rides;
        }

        public static void AddRide(Ride ride)
        {
            Rides.Add(ride);
        }

        public static Ride GetRideById(Guid id)
        {
            return Rides.Find(x => x.Id == id);
        }

        public static List<Ride> GetAllActiveRides()
        {
            return Rides.Where(x => x.IsActive).ToList();
        }

        public static List<Ride> GetRidesByUserPreferences(UserPreferences userPreferences)
        {
            var outputRides = new List<Ride>();

            var userId = userPreferences.UserId;
            var validGroupIds = GroupData.GetAllGroups().Where(g => g.Members.Select(m => m.Id).Contains(userId)).Select(g => g.Id).ToList();

            var activeRides = Rides.Where(r => r.IsActive);

            var startMatchedRides = new List<Ride>();
            var endMatchedRides = new List<Ride>();

            foreach(var ride in activeRides)
            {
                if (validGroupIds.Contains(ride.SharedGroupId))
                {
                    if (ride.StartTime >= userPreferences.StartTime.AddMinutes(-userPreferences.MaxDeviationInMinutes) && ride.StartTime <= userPreferences.StartTime.AddMinutes(userPreferences.MaxDeviationInMinutes))
                    {
                        if (ride.ProbabaleEndTime >= userPreferences.EndTime.AddMinutes(-userPreferences.MaxDeviationInMinutes) && ride.ProbabaleEndTime <= userPreferences.EndTime.AddMinutes(userPreferences.MaxDeviationInMinutes))
                        {
                            var userStartLocation = new GeoCoordinate(userPreferences.StartLocation.Latitude, userPreferences.StartLocation.Longitude);
                            var userEndLocation = new GeoCoordinate(userPreferences.Destination.Latitude, userPreferences.Destination.Longitude);

                            foreach (var waypoint in ride.RideRoute.WayPoints)
                            {
                                var waypointLocation = new GeoCoordinate(waypoint.Latitude, waypoint.Longitude);
                                var dist = userStartLocation.GetDistanceTo(waypointLocation);
                                if (dist < userPreferences.MaxWalkDistanceInMeters)
                                {
                                    startMatchedRides.Add(ride);
                                    break;
                                }
                            }

                            foreach (var waypoint in ride.RideRoute.WayPoints)
                            {
                                var waypointLocation = new GeoCoordinate(waypoint.Latitude, waypoint.Longitude);
                                if (userEndLocation.GetDistanceTo(waypointLocation) < userPreferences.MaxWalkDistanceInMeters)
                                {
                                    endMatchedRides.Add(ride);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            outputRides = startMatchedRides.Intersect(endMatchedRides).ToList();
            return outputRides;
        }
    }
}
