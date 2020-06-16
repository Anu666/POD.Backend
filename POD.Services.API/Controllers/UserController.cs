namespace POD.Services.API.Controllers
{
    using System;

    using Microsoft.AspNetCore.Mvc;

    using POD.Models;
    using POD.StaticData;

    /// <summary>
    /// The User controller.
    /// </summary>
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("getall")]
        public ActionResult GetAllUsers()
        {
            var users = PodUserData.GetUsers();
            return this.Ok(users);
        }

        [HttpGet]
        [Route("getbyid/{id:Guid}")]
        public ActionResult GetUserById(System.Guid id)
        {
            var user = PodUserData.GetUserById(id);
            return this.Ok(user);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult AddUser([FromBody]PodUser podUser)
        {
            PodUserData.AddUser(podUser);
            return this.Ok();
        }
    }
}
