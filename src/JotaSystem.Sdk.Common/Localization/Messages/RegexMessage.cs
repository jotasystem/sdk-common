namespace JotaSystem.Sdk.Common.Localization.Messages
{
    public static class RegexMessage
    {
        public static string InvalidPattern(string fieldName, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.EnUs => $"{fieldName} does not match the expected pattern.",
                Language.EsEs => $"{fieldName} no coincide con el patrón esperado.",
                _ => $"{fieldName} não corresponde ao padrão esperado."
            };
    }
}