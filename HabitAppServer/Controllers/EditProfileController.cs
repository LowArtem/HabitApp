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

        public EditProfileController(IRepository<User> repository)
        {
            this._editer = new BL.EditProfile(repository);
        }




        [HttpPut]
        public async Task<ActionResult<User>> Edit([FromQuery] int id, [FromBody] User user)
        {
            var new_user = await _editer.Edit(id, user.Description, user.Avatar, user.Username);

            if (new_user is null) return new BadRequestObjectResult(user);

            return new_user;
        }
    }
}
