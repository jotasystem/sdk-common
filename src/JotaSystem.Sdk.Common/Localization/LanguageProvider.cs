using System.Globalization;

namespace JotaSystem.Sdk.Common.Localization
{
    public static class LanguageProvider
    {
        // Idioma padrão global do SDK
        public static Language DefaultLanguage { get; private set; } = Language.PtBr;

        public static void SetDefault(Language language)
        {
            DefaultLanguage = language;
        }

        // Usa o idioma informado ou o padrão
        public static Language Use(Language? lang) => lang ?? DefaultLanguage;


        /// <summary>
        /// Converte CultureInfo ("pt-BR") para Language enum.
        /// </summary>
        public static Language FromCulture(CultureInfo culture)
        {
            return FromCode(culture.Name);
        }

        /// <summary>
        /// Converte código "pt-BR" ou "pt" para Language.
        /// </summary>
        public static Language FromCode(string code)
        {
            switch (code.ToLower())
            {
                case "pt-br":
                case "pt":
                    return Language.PtBr;

                case "en-us":
                case "en":
                    return Language.EnUs;

                case "es-es":
                case "es":
                    return Language.EsEs;

                default:
                    return DefaultLanguage; // fallback seguro
            }
        }

        /// <summary>
        /// Retorna o código da cultura baseado no enum.
        /// </summary>
        public static string GetCode(Language? language = null)
        {
            return (language ?? DefaultLanguage) switch
            {
                Language.EnUs => "en-US",
                Language.EsEs => "es-ES",
                _ => "pt-BR"
            };
        }

        /// <summary>
        /// Converte o enum Language para CultureInfo.
        /// </summary>
        public static CultureInfo ToCulture(Language? language = null)
        {
            return new CultureInfo(GetCode(language));
        }
    }

    public enum Language
    {
        PtBr,   // Português do Brasil
        EnUs,   // Inglês dos EUA
        EsEs    // Espanhol da Espanha
    }
}