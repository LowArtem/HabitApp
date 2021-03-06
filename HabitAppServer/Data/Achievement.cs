﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HabitAppServer.Model.Interfaces;

namespace HabitAppServer.Data
{
    /// <summary>
    /// Класс достижений в базе данных
    /// 
    /// Эта таблица заполняется программистом только при определении конкретных достижений
    /// </summary>
    public class Achievement : IEntity
    {
        /// <summary>Id</summary>
        public long Id { get; set; }

        /// <summary>Описание достижения</summary>
        [Required]
        public string Description { get; set; }

        /// <summary>Аватар достижения (картинка)</summary>
        public byte[] Avatar { get; set; }

        /// <summary>Категория достижения</summary>
        [Required]
        public string Category { get; set; }

        /// <summary>Денежная награда за достижение</summary>
        public int CashReward { get; set; }

        /// <summary>Предметная награда за достижение</summary>
        public virtual ICollection<Reward> Rewards { get; set; } = null;

        /// <summary>Список пользователей с этим достижением</summary>
        public virtual ICollection<User> Users { get; set; }

        /// <summary>Список сообществ с этим достижением</summary>
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}
