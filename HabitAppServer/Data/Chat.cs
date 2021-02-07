using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HabitAppServer.Model.Interfaces;

namespace HabitAppServer.Data
{
    /// <summary>
    /// Класс чата в базе данных
    /// </summary>
    public class Chat : IEntity
    {
        /// <summary>Id</summary>
        public long Id { get; set; }

        /// <summary>Название чата</summary>
        [Required]
        public string Name { get; set; }

        /// <summary>Сообщения чата</summary>
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }

        /// <summary>ID сообщества, к которому привязан чат</summary>
        public long UserGroupId { get; set; }

        /// <summary>Сообщество чата (null, если это личный чат)</summary>
        public virtual UserGroup UserGroup { get; set; }

        /// <summary>Список участников чата</summary>
        public virtual ICollection<User> Users { get; set; }
    }
}
