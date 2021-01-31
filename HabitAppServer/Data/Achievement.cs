using System.Collections.Generic;

namespace HabitAppServer.Data
{
    /// <summary>
    /// Класс достижений в базе данных
    /// 
    /// Эта таблица заполняется программистом только при определении конкретных достижений
    /// </summary>
    public class Achievement
    {
        /// <summary>Id</summary>
        public int AchievementId { get; set; }

        /// <summary>Описание достижения</summary>
        public string Description { get; set; }

        /// <summary>Категория достижения</summary>
        public string Category { get; set; }

        /// <summary>Денежная награда за достижение</summary>
        public int CashReward { get; set; }

        /// <summary>Предметная награда за достижение</summary>
        public ICollection<Reward> Rewards { get; set; } = null;

        /// <summary>Список пользователей с этим достижением</summary>
        public ICollection<User> Users { get; set; }
    }
}
