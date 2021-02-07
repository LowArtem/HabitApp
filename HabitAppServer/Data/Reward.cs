using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HabitAppServer.Model.Interfaces;

namespace HabitAppServer.Data
{
    /// <summary>
    /// Предметная награда для пользователя (не деньги) в базе данных
    /// 
    /// Эта таблица заполняется программистом только при определении конкретных наград
    /// </summary>
    public class Reward : IEntity
    {
        /// <summary>Id</summary>
        public long Id { get; set; }

        /// <summary>Описание предмета</summary>
        [Required]
        public string Description { get; set; }

        /// <summary>Категория предмета</summary>
        [Required]
        public string Category { get; set; }

        /// <summary>Ссылка на достижения, если эта награда к каким-то достижениям</summary>
        public virtual ICollection<Achievement> Achievements { get; set; } = null;

        /// <summary>Ссылка на пользователей, кому принадлежат эти награды (пока они не будут активированы)</summary>
        public virtual ICollection<User> Users { get; set; }
    }
}
