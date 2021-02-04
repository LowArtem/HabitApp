using System;
using System.ComponentModel.DataAnnotations;
using HabitAppServer.Model.Interfaces;

namespace HabitAppServer.Data
{
    /// <summary>
    /// Класс сообщения в чате в базе данных
    /// </summary>
    public class ChatMessage : IEntity
    {
        /// <summary>Id</summary>
        public int Id { get; set; }

        /// <summary>Текст сообщения</summary>
        [Required]
        public string MessageText { get; set; }

        /// <summary>Дата и время сообщения</summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>Закреплено ли сообщение</summary>
        public bool IsPinned { get; set; } = false;

        /// <summary>Автор сообщения</summary>
        public virtual User User { get; set; }

        /// <summary>Чат, которому принадлежит сообщение</summary>
        public virtual Chat Chat { get; set; }
    }
}
