using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HabitAppServer.Data;
using HabitAppServer.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HabitAppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IRepository<User> _repository;

        public AuthorizationController(IRepository<User> user_reposit)
        {
            this._repository = user_reposit;
        }



        [HttpGet("[action]")]
        public ActionResult<int> Authorize(string login, string password)
        {
            var authorizer = new BL.Authorization(_repository);

            int? id = authorizer.Authorizate(login, password);

            if (id is null) return new UnauthorizedResult();

            return (int)id;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Registrate([FromBody] User user)
        {
            var authorizer = new BL.Authorization(_repository);

            int? id = await authorizer.RegistrateAsync(user);

            if (id is null) return new UnauthorizedResult();

            return (int)id;
        }
    }
}
