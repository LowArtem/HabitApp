using System.Threading.Tasks;
using HabitAppServer.Data;
using HabitAppServer.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HabitAppServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly BL.Authorization _authorizer;

        public AuthorizationController(IRepository<User> user_reposit)
        {
            this._authorizer = new BL.Authorization(user_reposit);
        }




        [HttpGet]
        public ActionResult<int> Authorize(string login, string password)
        {
            int? id = _authorizer.Authorizate(login, password);

            if (id is null) return new UnauthorizedResult();

            return (int)id;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _authorizer.GetUserAsync(id);

            if (user is null) return new UnauthorizedResult();

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Registrate([FromBody] User user)
        {
            int? id = await _authorizer.RegistrateAsync(user);

            if (id is null) return new UnauthorizedResult();

            return (int)id;
        }
    }
}
