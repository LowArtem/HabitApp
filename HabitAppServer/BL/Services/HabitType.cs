namespace HabitAppServer.BL.Services
{
    /// <summary>
    /// Тип привычки
    /// </summary>
    public struct HabitType
    {
        /// <summary>Ежедневная привычка</summary>
        public static readonly string EveryDay = "everyday";

        /// <summary>Еженедельная привычка</summary>
        public static readonly string EveryWeek = "everyweek";

        /// <summary>Ежемесячная привычка</summary>
        public static readonly string EveryMonth = "everymonth";

        /// <summary>Ежегодная привычка</summary>
        public static readonly string EveryYear = "everyyear";

        /// <summary>Обычная (многоразовая) позитивная или негативная привычка</summary>
        public static readonly string Standart = "standart";

        /// <summary>Привычка одновременно позитивная и негативная (питаться правильно/неправильно)</summary>
        public static readonly string StandartDouble = "standartdouble";

        /// <summary>Одноразовая привычка = задача</summary>
        public static readonly string OneTime = "onetime";


        /// <summary>
        /// Проверяет правильность типа привычки
        /// </summary>
        /// <param name="type">тип привычки</param>
        /// <returns></returns>
        public static bool IsTypeCorrect(string type)
        {
            if (type == HabitType.EveryDay) return true;
            if (type == HabitType.EveryWeek) return true;
            if (type == HabitType.EveryMonth) return true;
            if (type == HabitType.EveryYear) return true;
            if (type == HabitType.Standart) return true;
            if (type == HabitType.StandartDouble) return true;
            if (type == HabitType.OneTime) return true;

            return false;
        }
    }
}
