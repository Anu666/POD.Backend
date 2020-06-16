namespace POD.Services.API.Controllers
{
    using System;

    using Microsoft.AspNetCore.Mvc;

    using POD.Models;
    using POD.StaticData;

    /// <summary>
    /// The Ride controller.
    /// </summary>
    [ApiController]
    [Route("api/rides")]
    public class RideController : ControllerBase
    {
        [HttpGet]
        [Route("getall")]
        public ActionResult GetAllRides()
        {
            var rides = RideData.GetAllRides();
            return this.Ok(rides);
        }

        [HttpGet]
        [Route("getallactive")]
        public ActionResult GetAllActiveRides()
        {
            var rides = RideData.GetAllActiveRides();
            return this.Ok(rides);
        }

        [HttpGet]
        [Route("getbyid/{id:Guid}")]
        public ActionResult GetRideById(Guid id)
        {
            var ride = RideData.GetRideById(id);
            return this.Ok(ride);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult AddRide([FromBody]Ride ride)
        {
            RideData.AddRide(ride);
            return this.Ok();
        }

        [HttpPost]
        [Route("getbyuserpreferences")]
        public ActionResult GetRidesByUserPreferences([FromBody]UserPreferences userPreferences)
        {
            var rides = RideData.GetRidesByUserPreferences(userPreferences);
            return this.Ok(rides);
        }

    }
}
