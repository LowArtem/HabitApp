using System;
using System.Collections.Generic;
using HabitAppServer.Model.Interfaces;

namespace HabitAppServer.Data
{
    /// <summary>
    /// Класс для хранения даты в базе данных (чтобы можно было коллекцию DateTime сделать)
    /// </summary>
    public class CustomDateTime : IEntity
    {
        public int Id { get; set; }

        /// <summary>DateTime</summary>
        public DateTime DateTime { get; set; }

        public virtual ICollection<Habit> Habit { get; set; }
    }
}
