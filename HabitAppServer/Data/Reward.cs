using System.Collections.Generic;

namespace HabitAppServer.Data
{
    /// <summary>
    /// Предметная награда для пользователя (не деньги) в базе данных
    /// 
    /// Эта таблица заполняется программистом только при определении конкретных наград
    /// </summary>
    public class Reward
    {
        /// <summary>Id</summary>
        public int RewardId { get; set; }

        /// <summary>Описание предмета</summary>
        public string Description { get; set; }

        /// <summary>Категория предмета</summary>
        public string Category { get; set; }

        /// <summary>Ссылка на достижения, если эта награда к каким-то достижениям</summary>
        public ICollection<Achievement> Achievements { get; set; } = null;

        /// <summary>Ссылка на пользователей, кому принадлежат эти награды (пока они не будут активированы)</summary>
        public ICollection<User> Users { get; set; }
    }
}
