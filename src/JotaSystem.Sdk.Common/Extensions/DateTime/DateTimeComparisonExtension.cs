namespace JotaSystem.Sdk.Common.Extensions.DateTime
{
    /// <summary>
    /// Extensões para comparações e verificações de DateTime.
    /// </summary>
    public static class DateTimeComparisonExtension
    {
        /// <summary>
        /// Verifica se a data é um final de semana (sábado ou domingo).
        /// </summary>
        public static bool IsWeekend(this System.DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Verifica se a data é um dia útil (segunda a sexta).
        /// </summary>
        public static bool IsWeekday(this System.DateTime date)
        {
            return !date.IsWeekend();
        }

        /// <summary>
        /// Verifica se a data é hoje.
        /// </summary>
        public static bool IsToday(this System.DateTime date)
        {
            return date.Date == System.DateTime.Today;
        }

        /// <summary>
        /// Verifica se o ano da data é bissexto.
        /// </summary>
        public static bool IsLeapYear(this System.DateTime date)
        {
            return System.DateTime.IsLeapYear(date.Year);
        }
    }
}