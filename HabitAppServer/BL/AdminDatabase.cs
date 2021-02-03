using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HabitAppServer.Data;
using HabitAppServer.Model.Interfaces;

namespace HabitAppServer.BL
{
    /// <summary>
    /// Класс для ручного добавления Rewards и Achievements в базу данных
    /// </summary>
    public class AdminDatabase
    {
        private readonly IRepository<Reward> _rewards;
        private readonly IRepository<Achievement> _achievements;

        public AdminDatabase(IRepository<Reward> rewards, IRepository<Achievement> achievements)
        {
            this._rewards = rewards;
            this._achievements = achievements;
        }

        /// <summary>Добавить награды в БД</summary>
        public async Task AddRewards()
        {
            foreach (var item in GetRewards())
            {
                await _rewards.AddAsync(item);
            }
        }

        /// <summary>Добавить достижения в БД</summary>
        public async Task AddAchievements()
        {
            foreach (var item in GetAchievements())
            {
                await _achievements.AddAsync(item);
            }
        }


        private List<Reward> GetRewards()
        {
            return new List<Reward>
            {
                new Reward
                {
                    Category = "",
                    Description = "",
                },
                new Reward
                {
                    Category = "",
                    Description = "",
                },
            };
        }

        private List<Achievement> GetAchievements()
        {
            return new List<Achievement>
            {
                new Achievement
                {
                    Category = "",
                    Description = "",
                },
                new Achievement
                {
                    Category = "",
                    Description = "",
                },
            };
        }
    }
}
