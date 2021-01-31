using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabitAppServer.Data
{
    /// <summary>
    /// Класс сообщества пользователей в базе данных
    /// </summary>
    public class UserGroup
    {
        /// <summary>Id</summary>
        public int UserGroupId { get; set; }

        /// <summary>Название сообщества</summary>
        public string Name { get; set; }

        /// <summary>Язык сообщества</summary>
        public string Language { get; set; }

        /// <summary>Описание сообщества</summary>
        public string Description { get; set; }

        /// <summary>Вступительный взнос</summary>
        public int EntranceFee { get; set; }

        /// <summary>Дата создания сообщества</summary>
        public DateTime CreationDate { get; set; }

        /// <summary>Список достижений сообщества</summary>
        public ICollection<Achievement> Achievements { get; set; }

        /// <summary>Суммарный опыт всех участников сообщества</summary>
        public int TotalExperience { get; set; }

        /// <summary>Банк сообщества (деньги с пожертвований и вступительных взносов)</summary>
        public int Cash { get; set; }

        //TODO: добавить чат






        /// <summary>Ссылка на создателя сообщества (может управлять админами)</summary>
        public User Creator { get; set; }

        /// <summary>Список администраторов сообщества (не могут управлять админами, могут юзерами, могут банком)</summary>
        public ICollection<User> Administrators { get; set; }

        /// <summary>Список обычных пользователей сообщества</summary>
        public ICollection<User> Users { get; set; }
    }
}
