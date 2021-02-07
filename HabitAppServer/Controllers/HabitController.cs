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
        public async Task<ActionResult<long>> Create(long userId, [FromBody] Habit habit)
        {
            long? habitId = await _habitController.Create(userId, habit);

            if (habitId is null) return new BadRequestObjectResult(habit);

            return (long)habitId;
        }

        [HttpGet]
        public async Task<ActionResult<Habit>> Get(long userId, long habitId)
        {
            var habit = await _habitController.GetHabit(userId, habitId);

            if (habit is null) return new BadRequestResult();

            return habit;
        }

        [HttpGet("[action]")]        
        public async Task<ActionResult<ICollection<Habit>>> GetAll(long userId)
        {
            var habits = await _habitController.GetAllHabits(userId);

            if (habits is null) return new BadRequestResult();

            return new OkObjectResult(habits);
        }

        [HttpPut]
        public async Task<ActionResult> Update(long userId, long habitId, [FromBody] Habit habit)
        {
            long? new_habitId = await _habitController.Update(userId, habitId, habit.Description, habit.Type, habit.Category, habit.Avatar,
                habit.CompletionsGoal);

            if (new_habitId is null) return new BadRequestResult();

            return new OkResult();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> Archieve(long userId, long habitId)
        {
            var new_habitId = await _habitController.Archieve(userId, habitId);

            if (new_habitId is null) return new BadRequestResult();

            return new OkResult();
        }

        [HttpDelete]
        public async Task<ActionResult<Habit>> Delete(long userId, long habitId)
        {
            var habit = await _habitController.Delete(userId, habitId);

            if (habit is null) return new EmptyResult();

            return habit;
        }
    }
}
