namespace JotaSystem.Sdk.Common.Extensions.DateTime
{
    /// <summary>
    /// Extensões para manipulação de datas.
    /// </summary>
    public static class DateTimeManipulationExtensions
    {
        /// <summary>
        /// Adiciona dias úteis, ignorando finais de semana.
        /// </summary>
        public static System.DateTime AddBusinessDays(this System.DateTime date, int days)
        {
            if (days == 0) return date;
            int direction = days > 0 ? 1 : -1;
            int added = 0;
            System.DateTime current = date;
            while (added < Math.Abs(days))
            {
                current = current.AddDays(direction);
                if (current.IsWeekday()) added++;
            }
            return current;
        }

        /// <summary>
        /// Retorna o próximo dia da semana especificado.
        /// </summary>
        public static System.DateTime NextDayOfWeek(this System.DateTime date, DayOfWeek dayOfWeek)
        {
            int diff = ((int)dayOfWeek - (int)date.DayOfWeek + 7) % 7;
            return date.AddDays(diff == 0 ? 7 : diff);
        }

        /// <summary>
        /// Retorna o dia da semana anterior especificado.
        /// </summary>
        public static System.DateTime PreviousDayOfWeek(this System.DateTime date, DayOfWeek dayOfWeek)
        {
            int diff = ((int)date.DayOfWeek - (int)dayOfWeek + 7) % 7;
            return date.AddDays(diff == 0 ? -7 : -diff);
        }

        /// <summary>
        /// Adiciona meses de forma segura, ajustando dias para meses menores.
        /// </summary>
        public static System.DateTime AddMonthsSafe(this System.DateTime date, int months)
        {
            int day = Math.Min(date.Day, System.DateTime.DaysInMonth(date.Year, date.Month + months));
            return new System.DateTime(date.Year, date.Month, day).AddMonths(months);
        }

        /// <summary>
        /// Adiciona anos de forma segura, ajustando dias para anos bissextos.
        /// </summary>
        public static System.DateTime AddYearsSafe(this System.DateTime date, int years)
        {
            int day = Math.Min(date.Day, System.DateTime.DaysInMonth(date.Year + years, date.Month));
            return new System.DateTime(date.Year + years, date.Month, day);
        }
    }
}