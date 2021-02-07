using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HabitAppServer.Data;
using HabitAppServer.Model.Interfaces;

namespace HabitAppServer.BL
{
    /// <summary>
    /// Класс для основных операций с привычками (создание, редактирование, получение, удаление)
    /// </summary>
    public class HabitCRUD
    {
        private readonly IRepository<Habit> _habits;
        private readonly IRepository<User> _users;

        public HabitCRUD(IRepository<Habit> habits, IRepository<User> users)
        {
            this._habits = habits;
            this._users = users;
        }



        public async Task<int?> Create(int userId, Habit habit)
        {
            if (habit is null || string.IsNullOrEmpty(habit.Description) || string.IsNullOrEmpty(habit.Category) ||
                string.IsNullOrEmpty(habit.Type))
            {
                return null;
            }

            var user = await _users.GetAsync(userId);
            if (user is null) return null;

            habit.CreationDate = DateTime.Now;
            habit.User = user;

            var new_habit = await _habits.AddAsync(habit);

            return new_habit.Id;
        }

        public async Task<int?> Update(int userId, int habitId, string description = null, string type = null, string category = null,
                                       byte[] avatar = null, int? goal = -1)
        {
            var user = await _users.GetAsync(userId);
            if (user is null) return null;

            var habit = user.Habits.SingleOrDefault(h => h.Id == habitId);
            if (habit is null) return null;

            if (!string.IsNullOrEmpty(description))
                habit.Description = description;

            if (!string.IsNullOrEmpty(type))
                habit.Type = type;

            if (!string.IsNullOrEmpty(category))
                habit.Category = category;

            if (avatar != null && avatar.Count() > 0)
                habit.Avatar = avatar;

            if (goal != -1)
                habit.CompletionsGoal = goal;

            await _habits.UpdateAsync(habit);

            return habit.Id;
        }

        public async Task<Habit> GetHabit(int userId, int habitId)
        {
            var user = await _users.GetAsync(userId);
            if (user is null) return null;

            return user.Habits.SingleOrDefault(h => h.Id == habitId);
        }

        public async Task<ICollection<Habit>> GetAllHabits(int userId)
        {
            var user = await _users.GetAsync(userId);
            if (user is null) return null;

            return user.Habits;
        }

        public async Task<Habit> Delete(int userId, int habitId)
        {
            var user = await _users.GetAsync(userId);
            if (user is null) return null;

            var habit = user.Habits.SingleOrDefault(h => h.Id == habitId);
            if (habit is null) return null;

            await _habits.RemoveAsync(habitId);

            return habit;
        }

        public async Task<int?> Archieve(int userId, int habitId)
        {
            var user = await _users.GetAsync(userId);
            if (user is null) return null;

            var habit = user.Habits.SingleOrDefault(h => h.Id == habitId);
            if (habit is null) return null;

            habit.IsHabitArchived = true;
            await _habits.UpdateAsync(habit);

            return habitId;
        }
    }
}
