namespace JotaSystem.Sdk.Common.Extensions.DateTime
{
    /// <summary>
    /// Extensões para início e fim de períodos de DateTime.
    /// </summary>
    public static class DateTimePeriodExtension
    {
        /// <summary>
        /// Retorna o início do dia (00:00:00) da data.
        /// </summary>
        public static System.DateTime StartOfDay(this System.DateTime date) => date.Date;

        /// <summary>
        /// Retorna o fim do dia (23:59:59.999) da data.
        /// </summary>
        public static System.DateTime EndOfDay(this System.DateTime date) => date.Date.AddDays(1).AddMilliseconds(-1);

        /// <summary>
        /// Retorna o primeiro dia do mês da data.
        /// </summary>
        public static System.DateTime StartOfMonth(this System.DateTime date) => new System.DateTime(date.Year, date.Month, 1);

        /// <summary>
        /// Retorna o último dia do mês da data.
        /// </summary>
        public static System.DateTime EndOfMonth(this System.DateTime date) =>
            new System.DateTime(date.Year, date.Month, System.DateTime.DaysInMonth(date.Year, date.Month)).EndOfDay();

        /// <summary>
        /// Retorna o número total de dias existentes no mês da data especificada.
        /// </summary>
        public static int DaysInMonth(this System.DateTime date) => System.DateTime.DaysInMonth(date.Year, date.Month);

        /// <summary>
        /// Retorna o primeiro dia do ano da data.
        /// </summary>
        public static System.DateTime StartOfYear(this System.DateTime date) => new(date.Year, 1, 1);

        /// <summary>
        /// Retorna o último dia do ano da data.
        /// </summary>
        public static System.DateTime EndOfYear(this System.DateTime date) => new System.DateTime(date.Year, 12, 31).EndOfDay();

        /// <summary>
        /// Retorna o início da semana considerando um dia inicial opcional (padrão segunda-feira).
        /// </summary>
        public static System.DateTime StartOfWeek(this System.DateTime date, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            int diff = (7 + (date.DayOfWeek - startOfWeek)) % 7;
            return date.AddDays(-diff).StartOfDay();
        }

        /// <summary>
        /// Retorna o fim da semana considerando um dia inicial opcional (padrão segunda-feira).
        /// </summary>
        public static System.DateTime EndOfWeek(this System.DateTime date, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            return date.StartOfWeek(startOfWeek).AddDays(6).EndOfDay();
        }
    }
}