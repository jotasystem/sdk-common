namespace JotaSystem.Sdk.Common.Localization
{
    public static class LanguageProvider
    {
        // Idioma padrão global do SDK
        public static Language DefaultLanguage { get; private set; } = Language.Pt;

        public static void SetDefault(Language language)
        {
            DefaultLanguage = language;
        }

        // Método auxiliar para usar o idioma informado ou o padrão
        public static Language Use(Language? lang) => lang ?? DefaultLanguage;

        // Método opcional para retornar o código (string) se precisar
        public static string GetCode(Language? language = null)
        {
            return (language ?? DefaultLanguage) switch
            {
                Language.En => "en",
                Language.Es => "es",
                _ => "pt"
            };
        }
    }
}