namespace POD.Services.API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using POD.Models;
    using POD.StaticData;

    /// <summary>
    /// The Notification controller.
    /// </summary>
    [ApiController]
    [Route("api/notifications")]
    public class NotificationController : ControllerBase
    {
        //[HttpPost]
        //[Route("sendtoall")]
        //public ActionResult SendNotificationToAll([FromBody]RequestNotification notification)
        //{
        //    var users = PodUserData.GetUsers();
        //    return this.Ok(users);
        //}

        //[HttpPost]
        //[Route("sendtogroup")]
        //public ActionResult SendNotificationToGroup(List<string> registrationIds, )
        //{
        //}

        //private async Task SendNotification()
    }
}
