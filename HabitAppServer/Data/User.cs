using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HabitAppServer.Model.Interfaces;

namespace HabitAppServer.Data
{
    /// <summary>
    /// Класс пользователя в базе данных
    /// </summary>
    public class User : IEntity
    {
        /// <summary>Id</summary>
        public int Id { get; set; }

        /// <summary>Имя пользователя</summary>
        [Required]
        public string Username { get; set; }

        /// <summary>Аватар пользователя (картинка)</summary>
        public byte[] Avatar { get; set; }

        /// <summary>Адрес электронной почты</summary>
        [Required]
        public string Login { get; set; }

        /// <summary>Пароль</summary>
        [Required]
        public string Password { get; set; }

        /// <summary>Статус игрока в сети (online/offline)</summary>
        public string OnlineStatus { get; set; }

        /// <summary>Дата регистрации пользователя</summary>
        [Required]
        public DateTime RegistrationDate { get; set; }

        /// <summary>Денег на счету</summary>
        public int Cash { get; set; }

        /// <summary>Игровой опыт</summary>
        public int Experience { get; set; }

        /// <summary>О себе от пользователя</summary>
        public string Description { get; set; }

        /// <summary>Последнее посещение</summary>
        public DateTime LastVisit { get; set; }

        /// <summary>Список всех его привычек</summary>
        public virtual ICollection<Habit> Habits { get; set; }

        /// <summary>Список всех достижений пользователя</summary>
        public virtual ICollection<Achievement> Achievements { get; set; }

        /// <summary>Список неактивированных наград пользователя</summary>
        public virtual ICollection<Reward> Rewards { get; set; }

        /// <summary>Сообщество, в которое входит пользователь</summary>
        public virtual UserGroup UserGroups { get; set; }

        /// <summary>Статус пользователя в сообществе (глава, админ, участник)</summary>
        public string UserGroupStatus { get; set; }

        /// <summary>Список всех сообщений пользователя</summary>
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }

        /// <summary>Список чатов пользователя</summary>
        public virtual ICollection<Chat> Chats { get; set; }

        /// <summary>Список моих друзей</summary>
        [InverseProperty("WhoseFriendIAm")]
        public virtual ICollection<User> MyFriends { get; set; }

        /// <summary>Список людей, у кого я в друзьях (не использовать это свойство, оно нужно для навигации)</summary>
        [InverseProperty("MyFriends")]
        public virtual ICollection<User> WhoseFriendIAm { get; set; }
    }
}
