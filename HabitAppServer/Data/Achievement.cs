using System.Collections.Generic;

namespace HabitAppServer.Data
{
    /// <summary>
    /// Класс достижений в базе данных
    /// </summary>
    public class Achievement
    {
        /// <summary>Id</summary>
        public int AchievementId { get; set; }

        /// <summary>Описание достижения</summary>
        public string Description { get; set; }

        /// <summary>Категория достижения</summary>
        public string Category { get; set; }



        // TODO: необходимость этого свойства зависит от введения внутренней валюты



        /// <summary>Награда за достижение</summary>
        public int Reward { get; set; }







        /// <summary>Список пользователей с этим достижением</summary>
        public virtual ICollection<User> Users { get; set; }
    }
}
