using System.Collections.Generic;
using HabitAppServer.Model;

namespace HabitAppServer.Data
{
    /// <summary>
    /// Класс чата в базе данных
    /// </summary>
    public class Chat : IEntity
    {
        /// <summary>Id</summary>
        public int Id { get; set; }

        /// <summary>Название чата</summary>
        public string Name { get; set; }

        /// <summary>Сообщения чата</summary>
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }

        /// <summary>Сообщество чата (null, если это личный чат)</summary>
        public virtual UserGroup UserGroup { get; set; }

        /// <summary>Список участников чата</summary>
        public virtual ICollection<User> Users { get; set; }
    }
}
