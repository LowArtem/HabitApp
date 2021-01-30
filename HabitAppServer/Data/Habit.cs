using System;
using System.Collections.Generic;

namespace HabitAppServer.Data
{
    /// <summary>
    /// Класс привычки в базе данных (может быть позитивной/негативной)
    /// </summary>
    public class Habit
    {
        /// <summary>Id</summary>
        public int HabitId { get; set; }

        /// <summary>Описание привычки</summary>
        public string Description { get; set; }

        /// <summary>Категория привычки</summary>
        public string Category { get; set; }

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




        public Habit(string description, string category, int completionsGoal, int currentCompletions, bool isPositive, bool isHabitArchived, User user, DateTime creationDate)
        {
            this.Description = description;
            this.Category = category;
            this.CompletionsGoal = completionsGoal;
            this.CurrentCompletions = currentCompletions;
            this.IsPositive = isPositive;
            this.IsHabitArchived = isHabitArchived;
            this.User = user;
            this.CreationDate = creationDate;
        }

        public Habit() { }
    }
}
