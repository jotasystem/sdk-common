using System.Text.RegularExpressions;

namespace JotaSystem.Sdk.Common.Extensions.String
{
    /// <summary>
    /// Métodos de extensão para limpeza e normalização de strings.
    /// Inclui remoção de HTML, caracteres não imprimíveis e normalização de espaços.
    /// </summary>
    public static class StringCleaningExtension
    {
        /// <summary>
        /// Remove todas as tags HTML de uma string.
        /// </summary>
        /// <param name="value">Texto que pode conter tags HTML.</param>
        /// <returns>Texto limpo, sem tags HTML.</returns>
        public static string RemoveHtmlTags(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            return Regex.Replace(value, "<.*?>", string.Empty);
        }

        /// <summary>
        /// Remove caracteres não imprimíveis (como caracteres de controle e invisíveis).
        /// </summary>
        /// <param name="value">Texto que pode conter caracteres especiais.</param>
        /// <returns>Texto contendo apenas caracteres imprimíveis.</returns>
        public static string RemoveNonPrintableChars(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return new string(value.Where(c => !char.IsControl(c)).ToArray());
        }

        /// <summary>
        /// Remove espaços em branco extras e substitui múltiplos espaços por um único.
        /// </summary>
        /// <param name="value">Texto com possíveis espaços em excesso.</param>
        /// <returns>Texto com espaçamento normalizado.</returns>
        public static string NormalizeWhitespace(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            var cleaned = Regex.Replace(value, @"\s+", " ").Trim();
            return cleaned;
        }

        /// <summary>
        /// Remove todos os caracteres que não sejam letras, números ou espaços.
        /// </summary>
        /// <param name="value">Texto que pode conter símbolos ou pontuações.</param>
        /// <returns>Texto contendo apenas letras, números e espaços.</returns>
        public static string RemoveSpecialCharacters(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return Regex.Replace(value, @"[^a-zA-Z0-9\s]", string.Empty);
        }

        /// <summary>
        /// Remove todas as quebras de linha (\r, \n) da string.
        /// </summary>
        /// <param name="value">Texto com possíveis quebras de linha.</param>
        /// <returns>Texto em linha única.</returns>
        public static string RemoveLineBreaks(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return value.Replace("\r", string.Empty).Replace("\n", string.Empty);
        }

        /// <summary>
        /// Remove espaços no início e no final e normaliza múltiplos espaços internos.
        /// </summary>
        /// <param name="value">Texto de entrada.</param>
        /// <returns>Texto limpo com espaços ajustados.</returns>
        public static string CleanSpaces(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            return Regex.Replace(value.Trim(), @"\s{2,}", " ");
        }

        /// <summary>
        /// Remove caracteres de tabulação (\t) da string.
        /// </summary>
        /// <param name="value">Texto com possíveis tabulações.</param>
        /// <returns>Texto sem caracteres de tabulação.</returns>
        public static string RemoveTabs(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return value.Replace("\t", string.Empty);
        }

        /// <summary>
        /// Remove pontuações comuns (como .,!?;:).
        /// </summary>
        /// <param name="value">Texto com possíveis sinais de pontuação.</param>
        /// <returns>Texto sem pontuação.</returns>
        public static string RemovePunctuation(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return Regex.Replace(value, @"[.,!?;:]", string.Empty);
        }
    }
}