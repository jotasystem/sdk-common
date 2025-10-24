namespace JotaSystem.Sdk.Common.Localization.Messages
{
    public static class GenericMessage
    {
        public static string InvalidOperation(string details, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.EnUs => $"Invalid operation: {details}.",
                Language.EsEs => $"Operación inválida: {details}.",
                _ => $"Operação inválida: {details}."
            };
    }
}