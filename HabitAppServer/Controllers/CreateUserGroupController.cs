using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HabitAppServer.BL;
using HabitAppServer.Data;
using HabitAppServer.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HabitAppServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CreateUserGroupController : Controller
    {
        private readonly CreateUserGroup createUserGroup;

        public CreateUserGroupController(IRepository<User> users, IRepository<UserGroup> userGroups, IRepository<Chat> chats)
        {
            createUserGroup = new CreateUserGroup(users, userGroups, chats);
        }


        [HttpPost]
        public async Task<ActionResult<int>> CreateGroup(int groupCreatorId, string name, string language = "en", [FromBody] ICollection<int> friendsIds = null)
        {
            int? groupId = await createUserGroup.Create(groupCreatorId, name, language, friendsIds);

            if (groupId is null) return new BadRequestResult();

            return groupId;
        }
    }
}
