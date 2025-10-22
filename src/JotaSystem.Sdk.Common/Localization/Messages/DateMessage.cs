namespace JotaSystem.Sdk.Common.Localization.Messages
{
    public static class DateMessage
    {
        public static string MustBeFuture(string fieldName, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.EnUs => $"{fieldName} must be a future date.",
                Language.EsEs => $"{fieldName} debe ser una fecha futura.",
                _ => $"{fieldName} deve ser uma data futura."
            };

        public static string MustBePast(string fieldName, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.EnUs => $"{fieldName} must be a past date.",
                Language.EsEs => $"{fieldName} debe ser una fecha pasada.",
                _ => $"{fieldName} deve ser uma data passada."
            };

        public static string OutOfRange(string fieldName, DateTime min, DateTime max, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.EnUs => $"{fieldName} must be between {min:d} and {max:d}.",
                Language.EsEs => $"{fieldName} debe estar entre {min:d} y {max:d}.",
                _ => $"{fieldName} deve estar entre {min:d} e {max:d}."
            };
    }
}