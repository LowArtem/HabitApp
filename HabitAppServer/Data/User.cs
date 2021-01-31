using System;
using System.Collections.Generic;

namespace HabitAppServer.Data
{
    /// <summary>
    /// Класс пользователя в базе данных
    /// </summary>
    public class User
    {
        /// <summary>Id</summary>
        public int UserId { get; set; }

        /// <summary>Имя пользователя</summary>
        public string Username { get; set; }

        /// <summary>Адрес электронной почты</summary>
        public string Login { get; set; }

        /// <summary>Пароль</summary>
        public string Password { get; set; }

        /// <summary>Дата регистрации пользователя</summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>Денег на счету</summary>
        public int Cash { get; set; }

        /// <summary>Игровой опыт</summary>
        public int Experience { get; set; }

        /// <summary>Список всех его привычек</summary>
        public ICollection<Habit> Habits { get; set; }

        /// <summary>Список всех достижений пользователя</summary>
        public ICollection<Achievement> Achievements { get; set; }

        /// <summary>Список неактивированных наград пользователя</summary>
        public ICollection<Reward> Rewards { get; set; }
    }
}
