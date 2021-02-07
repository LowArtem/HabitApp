using System.Threading.Tasks;
using HabitAppServer.BL;
using HabitAppServer.Data;
using HabitAppServer.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HabitAppServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EditProfileController : ControllerBase
    {
        private readonly EditProfile _editer;
        private readonly IRepository<Achievement> achievementsRepo;
        private readonly IRepository<Reward> rewardsRepo;
        private readonly IRepository<UserGroup> usergroupsRepo;
        private readonly IRepository<Chat> chatsRepo;
        private readonly IRepository<ChatMessage> chatmsgRepo;

        public EditProfileController(IRepository<User> userRepo, IRepository<Achievement> achievementsRepo,
            IRepository<Reward> rewardsRepo, IRepository<UserGroup> usergroupsRepo, IRepository<Chat> chatsRepo,
            IRepository<ChatMessage> chatmsgRepo)
        {
            this._editer = new BL.EditProfile(userRepo);
            this.achievementsRepo = achievementsRepo;
            this.rewardsRepo = rewardsRepo;
            this.usergroupsRepo = usergroupsRepo;
            this.chatsRepo = chatsRepo;
            this.chatmsgRepo = chatmsgRepo;
        }




        [HttpPut]
        public async Task<ActionResult<User>> Edit([FromQuery] int id, [FromBody] User user)
        {
            var new_user = await _editer.Edit(id, user.Description, user.Avatar, user.Username);

            if (new_user is null) return new BadRequestObjectResult(user);

            return new_user;
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUserAccount(int userId, string login, string password)
        {
            var id = await _editer.DeleteUserAccount(userId, login, password, achievementsRepo, rewardsRepo, usergroupsRepo, 
                chatsRepo, chatmsgRepo);

            if (id is null) return new UnauthorizedResult();

            return new OkResult();
        }
    }
}
