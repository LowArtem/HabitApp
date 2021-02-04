using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HabitAppServer.Model.Interfaces;

namespace HabitAppServer.Data
{
    /// <summary>
    /// Класс привычки в базе данных (может быть позитивной/негативной)
    /// </summary>
    public class Habit : IEntity
    {
        /// <summary>Id</summary>
        public int Id { get; set; }

        /// <summary>Описание привычки</summary>
        [Required]
        public string Description { get; set; }

        /// <summary>Аватар привычки (картинка)</summary>
        public byte[] Avatar { get; set; }

        /// <summary>Категория привычки (спорт, учеба, здоровье...)</summary>
        [Required]
        public string Category { get; set; }

        /// <summary>Вид привычки (ежедневная, обязательная, обычная...)</summary>
        [Required]
        public string Type { get; set; }

        /// <summary>Целевое количество выполнений привычки (если null значит неограниченное кол-во выполнений)</summary>
        public int? CompletionsGoal { get; set; } = null;

        /// <summary>Текущее количество выполнений привычки</summary>
        public int CurrentCompletions { get; set; }

        /// <summary>Дата создания привычки</summary>
        [Required]
        public DateTime CreationDate { get; set; }

        /// <summary>Это хорошая привычка, или плохая</summary>
        public bool IsPositive { get; set; } = true;

        /// <summary>Флаг, заархивирована ли эта привычка</summary>
        public bool IsHabitArchived { get; set; } = false;

        /// <summary>Даты выполнения привычки</summary>
        public virtual ICollection<CustomDateTime> CompletionsDates { get; set; }

        /// <summary>Ссылка на пользователя, владельца этих привычек</summary>
        public virtual User User { get; set; }
    }
}
