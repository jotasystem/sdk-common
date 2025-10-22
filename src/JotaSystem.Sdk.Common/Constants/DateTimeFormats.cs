namespace JotaSystem.Sdk.Common.Constants
{
    public static class DateTimeFormats
    {
        // 🔹 Datas
        public const string ShortDate = "dd/MM/yyyy";               // 22/10/2025
        public const string ShortDateYearFirst = "yyyy-MM-dd";     // 2025-10-22
        public const string LongDate = "dd/MM/yyyy HH:mm:ss";      // 22/10/2025 13:45:30
        public const string LongDateWithMilliseconds = "dd/MM/yyyy HH:mm:ss.fff"; // 22/10/2025 13:45:30.123

        // 🔹 ISO / Padrão internacional
        public const string Iso8601 = "yyyy-MM-ddTHH:mm:ssZ";      // 2025-10-22T13:45:30Z
        public const string Iso8601WithMilliseconds = "yyyy-MM-ddTHH:mm:ss.fffZ"; // 2025-10-22T13:45:30.123Z
        public const string Iso8601Local = "yyyy-MM-ddTHH:mm:ssK"; // Com offset local: 2025-10-22T13:45:30-03:00

        // 🔹 Hora
        public const string ShortTime = "HH:mm";                   // 13:45
        public const string LongTime = "HH:mm:ss";                // 13:45:30
        public const string LongTimeWithMilliseconds = "HH:mm:ss.fff"; // 13:45:30.123

        // 🔹 Data compacta (útil para logs ou nomes de arquivos)
        public const string CompactDate = "yyyyMMdd";              // 20251022
        public const string CompactDateTime = "yyyyMMddHHmmss";    // 20251022134530
        public const string CompactDateTimeWithMilliseconds = "yyyyMMddHHmmssfff"; // 20251022134530123

        // 🔹 Relatórios / human-readable
        public const string FullDateWithDayName = "dddd, dd MMMM yyyy"; // Quarta-feira, 22 outubro 2025
        public const string FullDateTimeWithDayName = "dddd, dd MMMM yyyy HH:mm:ss"; // Quarta-feira, 22 outubro 2025 13:45:30
    }
}