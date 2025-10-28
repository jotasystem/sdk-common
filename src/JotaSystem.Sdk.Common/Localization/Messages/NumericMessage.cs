namespace JotaSystem.Sdk.Common.Localization.Messages
{
    public static class NumericMessage
    {
        public static string MustBePositive(string fieldName, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.EnUs => $"{fieldName} must be positive.",
                Language.EsEs => $"{fieldName} debe ser positivo.",
                _ => $"{fieldName} deve ser positivo."
            };

        public static string OutOfRange(string fieldName, decimal min, decimal max, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.EnUs => $"{fieldName} must be between {min} and {max}.",
                Language.EsEs => $"{fieldName} debe estar entre {min} y {max}.",
                _ => $"{fieldName} deve estar entre {min} e {max}."
            };

        public static string MustBeGreaterThan(string fieldName, decimal minValue, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.EnUs => $"{fieldName} must be greater than {minValue}.",
                Language.EsEs => $"{fieldName} debe ser mayor que {minValue}.",
                _ => $"{fieldName} deve ser maior que {minValue}."
            };

        public static string MustBeLessThan(string fieldName, decimal maxValue, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.EnUs => $"{fieldName} must be less than {maxValue}.",
                Language.EsEs => $"{fieldName} debe ser menor que {maxValue}.",
                _ => $"{fieldName} deve ser menor que {maxValue}."
            };

        public static string NotEnough(string fieldName, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.EnUs => $"{fieldName} is not enough.",
                Language.EsEs => $"{fieldName} no es suficiente.",
                _ => $"{fieldName} não é suficiente."
            };
    }
}
