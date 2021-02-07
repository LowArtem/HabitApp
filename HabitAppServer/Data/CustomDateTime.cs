﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HabitAppServer.Model.Interfaces;

namespace HabitAppServer.Data
{
    /// <summary>
    /// Класс для хранения даты в базе данных (чтобы можно было коллекцию DateTime сделать)
    /// </summary>
    public class CustomDateTime : IEntity
    {
        public long Id { get; set; }

        /// <summary>DateTime</summary>
        [Required]
        public DateTime DateTime { get; set; }

        public virtual ICollection<Habit> Habit { get; set; }
    }
}
