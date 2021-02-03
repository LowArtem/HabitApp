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
    /// <summary>
    /// Контроллер для ручного добавления достижений и наград в БД (можно будет позже написать web-интерфейс для удобства, чтобы не лазить каждый раз в код)
    /// </summary>
    /// 
    [Route("[admin]/[controller]/[action]")]
    [ApiController]
    public class AdminDatabaseController : ControllerBase
    {
        private readonly AdminDatabase adminDatabase;

        public AdminDatabaseController(IRepository<Reward> rewards, IRepository<Achievement> achievements)
        {
            adminDatabase = new AdminDatabase(rewards, achievements);
        }



        [HttpGet]
        public async Task AddNewDataInCode()
        {
            await adminDatabase.AddRewards();
            await adminDatabase.AddAchievements();
        }
    }
}
