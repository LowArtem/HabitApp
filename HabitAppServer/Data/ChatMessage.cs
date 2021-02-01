using System;

namespace HabitAppServer.Data
{
    /// <summary>
    /// Класс сообщения в чате в базе данных
    /// </summary>
    public class ChatMessage
    {
        /// <summary>Id</summary>
        public int ChatMessageId { get; set; }

        /// <summary>Текст сообщения</summary>
        public string MessageText { get; set; }

        /// <summary>Дата и время сообщения</summary>
        public DateTime Date { get; set; }

        /// <summary>Закреплено ли сообщение</summary>
        public bool IsPinned { get; set; } = false;

        /// <summary>Автор сообщения</summary>
        public virtual User User { get; set; }

        /// <summary>Чат, которому принадлежит сообщение</summary>
        public virtual Chat Chat { get; set; }
    }
}
