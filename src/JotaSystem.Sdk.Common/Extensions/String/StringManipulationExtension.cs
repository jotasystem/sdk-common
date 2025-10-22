using System.Text.RegularExpressions;

namespace JotaSystem.Sdk.Common.Extensions.String
{
    /// <summary>
    /// Métodos de extensão voltados à manipulação direta de strings, 
    /// incluindo extrações, remoções, filtragens e ajustes de formato.
    /// </summary>
    public static class StringManipulationExtension
    {
        /// <summary>
        /// Retorna o trecho da string entre dois delimitadores.
        /// Caso não encontre, retorna string vazia.
        /// </summary>
        public static string Between(this string value, string start, string end)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(start) || string.IsNullOrEmpty(end))
                return string.Empty;

            int startIndex = value.IndexOf(start);
            if (startIndex == -1) return string.Empty;

            startIndex += start.Length;
            int endIndex = value.IndexOf(end, startIndex);
            if (endIndex == -1) return string.Empty;

            return value[startIndex..endIndex];
        }

        /// <summary>
        /// Retorna os primeiros <paramref name="length"/> caracteres da string.
        /// </summary>
        public static string Left(this string value, int length)
        {
            if (string.IsNullOrEmpty(value) || length <= 0)
                return string.Empty;

            return value.Length <= length ? value : value.Substring(0, length);
        }

        /// <summary>
        /// Retorna os últimos <paramref name="length"/> caracteres da string.
        /// </summary>
        public static string Right(this string value, int length)
        {
            if (string.IsNullOrEmpty(value) || length <= 0)
                return string.Empty;

            return value.Length <= length ? value : value[^length..];
        }

        /// <summary>
        /// Remove todos os números da string.
        /// </summary>
        public static string RemoveNumbers(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;
            return Regex.Replace(value, @"\d+", string.Empty);
        }

        /// <summary>
        /// Remove todas as letras da string, mantendo apenas números e símbolos.
        /// </summary>
        public static string RemoveLetters(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;
            return Regex.Replace(value, @"[A-Za-z]+", string.Empty);
        }

        /// <summary>
        /// Retorna apenas os números contidos na string.
        /// </summary>
        public static string OnlyNumbers(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;
            return Regex.Replace(value, @"[^\d]", string.Empty);
        }

        /// <summary>
        /// Retorna apenas as letras contidas na string.
        /// </summary>
        public static string OnlyLetters(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;
            return Regex.Replace(value, @"[^a-zA-Z]", string.Empty);
        }

        /// <summary>
        /// Garante que a string termine com determinado sufixo.
        /// </summary>
        public static string EnsureEndsWith(this string value, string suffix)
        {
            if (value == null) return suffix ?? string.Empty;
            if (string.IsNullOrEmpty(suffix)) return value;
            return value.EndsWith(suffix) ? value : value + suffix;
        }

        /// <summary>
        /// Garante que a string comece com determinado prefixo.
        /// </summary>
        public static string EnsureStartsWith(this string value, string prefix)
        {
            if (value == null) return prefix ?? string.Empty;
            if (string.IsNullOrEmpty(prefix)) return value;
            return value.StartsWith(prefix) ? value : prefix + value;
        }

        /// <summary>
        /// Retorna apenas as primeiras <paramref name="count"/> palavras da string.
        /// </summary>
        public static string LimitWords(this string value, int count)
        {
            if (string.IsNullOrWhiteSpace(value) || count <= 0)
                return string.Empty;

            var words = value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return string.Join(' ', words[..Math.Min(words.Length, count)]);
        }

        /// <summary>
        /// Preenche a string à esquerda até atingir o tamanho informado.
        /// </summary>
        public static string PadLeftCustom(this string value, int totalWidth, char padChar = ' ')
        {
            if (value == null) value = string.Empty;
            return value.PadLeft(totalWidth, padChar);
        }
    }
}