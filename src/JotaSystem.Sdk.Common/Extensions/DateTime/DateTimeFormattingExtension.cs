namespace JotaSystem.Sdk.Common.Extensions.DateTime
{
    /// <summary>
    /// Extensões para formatação rápida de DateTime.
    /// </summary>
    public static class DateTimeFormattingExtension
    {
        /// <summary>
        /// Retorna a string da data em formato ISO 8601 (yyyy-MM-ddTHH:mm:ss).
        /// </summary>
        public static string ToIsoString(this System.DateTime date) => date.ToString("yyyy-MM-ddTHH:mm:ss");

        /// <summary>
        /// Retorna a data em formato curto ou um valor padrão se nulo.
        /// </summary>
        public static string ToShortDateStringOrDefault(this System.DateTime? date, string defaultValue = "")
        {
            return date?.ToShortDateString() ?? defaultValue;
        }

        /// <summary>
        /// Retorna uma string amigável representando a diferença para agora.
        /// </summary>
        public static string ToFriendlyString(this System.DateTime date)
        {
            var span = System.DateTime.Now - date;
            if (span.TotalDays >= 1) return $"{(int)span.TotalDays} dia(s) atrás";
            if (span.TotalHours >= 1) return $"{(int)span.TotalHours} hora(s) atrás";
            if (span.TotalMinutes >= 1) return $"{(int)span.TotalMinutes} minuto(s) atrás";
            return "agora mesmo";
        }
    }
}