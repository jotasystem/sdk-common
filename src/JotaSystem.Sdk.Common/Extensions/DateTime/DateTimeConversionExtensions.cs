namespace JotaSystem.Sdk.Common.Extensions.DateTime
{
    /// <summary>
    /// Extensões para conversão de DateTime.
    /// </summary>
    public static class DateTimeConversionExtension
    {
        /// <summary>
        /// Converte a data para timestamp Unix (segundos desde 01/01/1970 UTC).
        /// </summary>
        public static long ToUnixTimestamp(this System.DateTime date)
        {
            var offset = new DateTimeOffset(date.ToUniversalTime());
            return offset.ToUnixTimeSeconds();
        }

        /// <summary>
        /// Converte um timestamp Unix para DateTime em UTC.
        /// </summary>
        public static System.DateTime FromUnixTimestamp(this long timestamp)
        {
            return DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime;
        }

        /// <summary>
        /// Converte a data para UTC de forma segura, sem alterar se já estiver em UTC.
        /// </summary>
        public static System.DateTime ToUtcSafe(this System.DateTime date)
        {
            return date.Kind == DateTimeKind.Utc ? date : date.ToUniversalTime();
        }

        /// <summary>
        /// Converte a data para horário local de forma segura, sem alterar se já estiver em Local.
        /// </summary>
        public static System.DateTime ToLocalTimeSafe(this System.DateTime date)
        {
            return date.Kind == DateTimeKind.Local ? date : date.ToLocalTime();
        }
    }
}