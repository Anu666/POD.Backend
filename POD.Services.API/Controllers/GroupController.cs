namespace POD.Services.API.Controllers
{
    using System;

    using Microsoft.AspNetCore.Mvc;

    using POD.Models;
    using POD.StaticData;

    [ApiController]
    [Route("api/groups")]
    public class GroupController : ControllerBase
    {
        [HttpGet]
        [Route("getall")]
        public ActionResult GetAllGroups()
        {
            var groups = GroupData.GetAllGroups();
            return this.Ok(groups);
        }

        [HttpGet]
        [Route("getbyid/{id:Guid}")]
        public ActionResult GetGroupById(Guid id)
        {
            var group = GroupData.GetGroupById(id);
            return this.Ok(group);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult AddGroup([FromBody]PodGroup podGroup)
        {
            GroupData.AddGroup(podGroup);
            return this.Ok();
        }
    }
}
