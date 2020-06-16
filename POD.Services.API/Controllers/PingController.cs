namespace POD.Services.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This controller contains a method which gives the service health.
    /// </summary>
    public class PingController : ControllerBase
    {
        /// <summary>
        /// The Index method to return service health.
        /// </summary>
        /// <returns>Http status Code of OK.</returns>
        [HttpGet]
        [Route("api/ping")]
        public ActionResult Index()
        {
            return this.Ok("pong");
        }
    }
}
