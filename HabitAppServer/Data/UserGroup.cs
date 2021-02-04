﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HabitAppServer.Model.Interfaces;

namespace HabitAppServer.Data
{
    /// <summary>
    /// Класс сообщества пользователей в базе данных
    /// </summary>
    public class UserGroup : IEntity
    {
        /// <summary>Id</summary>
        public int Id { get; set; }

        /// <summary>Название сообщества</summary>
        [Required]
        public string Name { get; set; }

        /// <summary>Аватар сообщества (картинка)</summary>
        public byte[] Avatar { get; set; }

        /// <summary>Язык сообщества</summary>
        [Required]
        public string Language { get; set; }

        /// <summary>Описание сообщества</summary>
        public string Description { get; set; }

        /// <summary>Вступительный взнос</summary>
        public int EntranceFee { get; set; }

        /// <summary>Дата создания сообщества</summary>
        [Required]
        public DateTime CreationDate { get; set; }

        /// <summary>Список достижений сообщества</summary>
        public virtual ICollection<Achievement> Achievements { get; set; }

        /// <summary>Суммарный опыт всех участников сообщества</summary>
        public int TotalExperience { get; set; }

        /// <summary>Банк сообщества (деньги с пожертвований и вступительных взносов)</summary>
        public int Cash { get; set; }

        /// <summary>Чат сообщества</summary>
        public virtual Chat GroupChat { get; set; }

        /// <summary>Список пользователей сообщества</summary>
        public virtual ICollection<User> Users { get; set; }
    }
}
