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
    [Route("api/[controller]")]
    [ApiController]
    public class HabitController : Controller
    {
        private readonly HabitCRUD _habitController;

        public HabitController(IRepository<Habit> habits, IRepository<User> users)
        {
            _habitController = new HabitCRUD(habits, users);
        }


        [HttpPost]
        public async Task<ActionResult<int>> Create(int userId, [FromBody] Habit habit)
        {
            int? habitId = await _habitController.Create(userId, habit);

            if (habitId is null) return new BadRequestObjectResult(habit);

            return (int)habitId;
        }

        [HttpGet]
        public async Task<ActionResult<Habit>> Get(int userId, int habitId)
        {
            var habit = await _habitController.GetHabit(userId, habitId);

            if (habit is null) return new BadRequestResult();

            return habit;
        }

        [HttpPut]
        public async Task<ActionResult> Update(int userId, int habitId, [FromBody] Habit habit)
        {
            int? new_habitId = await _habitController.Update(userId, habitId, habit.Description, habit.Type, habit.Category, habit.Avatar,
                habit.CompletionsGoal);

            if (new_habitId is null) return new BadRequestResult();

            return new OkResult();
        }

        [HttpDelete]
        public async Task<ActionResult<Habit>> Delete(int userId, int habitId)
        {
            var habit = await _habitController.Delete(userId, habitId);

            if (habit is null) return new EmptyResult();

            return habit;
        }
    }
}
