using System;
using System.Collections.Generic;
using HabitAppServer.Model;

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
        public string Description { get; set; }

        /// <summary>Аватар привычки (картинка)</summary>
        public byte[] Avatar { get; set; }

        /// <summary>Категория привычки (спорт, учеба, здоровье...)</summary>
        public string Category { get; set; }

        /// <summary>Вид привычки (ежедневная, обязательная, обычная...)</summary>
        public string Type { get; set; }

        /// <summary>Целевое количество выполнений привычки</summary>
        public int CompletionsGoal { get; set; }

        /// <summary>Текущее количество выполнений привычки</summary>
        public int CurrentCompletions { get; set; }

        /// <summary>Дата создания привычки</summary>
        public DateTime CreationDate { get; set; }

        /// <summary>Это хорошая привычка, или плохая</summary>
        public bool IsPositive { get; set; } = true;

        /// <summary>Флаг, заархивирована ли эта привычка</summary>
        public bool IsHabitArchived { get; set; } = false;

        /// <summary>Даты выполнения привычки</summary>
        public ICollection<DateTime> CompletionsDates { get; set; }

        /// <summary>Ссылка на пользователя, владельца этих привычек</summary>
        public virtual User User { get; set; }
    }
}
