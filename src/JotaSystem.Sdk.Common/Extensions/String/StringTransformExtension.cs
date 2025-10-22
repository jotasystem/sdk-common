using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace JotaSystem.Sdk.Common.Extensions.String
{
    /// <summary>
    /// Métodos de extensão para transformar o formato e estilo de strings.
    /// Inclui conversões de casing, remoção de acentuação e criação de slugs.
    /// </summary>
    public static class StringTransformExtension
    {
        /// <summary>
        /// Converte a primeira letra de cada palavra para maiúscula (Title Case).
        /// </summary>
        public static string ToTitleCase(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
        }

        /// <summary>
        /// Converte a string para o formato snake_case.
        /// </summary>
        public static string ToSnakeCase(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            var snake = Regex.Replace(value, "([a-z])([A-Z])", "$1_$2").ToLower();
            return Regex.Replace(snake, @"[\s-]+", "_");
        }

        /// <summary>
        /// Converte a string para o formato kebab-case.
        /// </summary>
        public static string ToKebabCase(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            var kebab = Regex.Replace(value, "([a-z])([A-Z])", "$1-$2").ToLower();
            return Regex.Replace(kebab, @"[\s_]+", "-");
        }

        /// <summary>
        /// Converte a string para o formato PascalCase.
        /// </summary>
        public static string ToPascalCase(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            var words = Regex.Split(value, @"[\s_\-]+");
            var builder = new StringBuilder();
            foreach (var word in words)
            {
                if (word.Length > 0)
                    builder.Append(char.ToUpperInvariant(word[0]) + word[1..].ToLowerInvariant());
            }
            return builder.ToString();
        }

        /// <summary>
        /// Converte a string para o formato camelCase.
        /// </summary>
        public static string ToCamelCase(this string value)
        {
            var pascal = value.ToPascalCase();
            if (string.IsNullOrEmpty(pascal)) return pascal;
            return char.ToLowerInvariant(pascal[0]) + pascal[1..];
        }

        /// <summary>
        /// Remove acentuação e caracteres especiais da string.
        /// </summary>
        public static string RemoveAccents(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            var normalized = value.Normalize(NormalizationForm.FormD);
            var builder = new StringBuilder();
            foreach (var c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    builder.Append(c);
            }
            return builder.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Cria um slug seguro para URLs a partir da string.
        /// </summary>
        public static string ToSlug(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            value = value.RemoveAccents().ToLowerInvariant();
            value = Regex.Replace(value, @"[^a-z0-9\s-]", "");
            value = Regex.Replace(value, @"\s+", " ").Trim();
            return Regex.Replace(value, @"\s", "-");
        }

        /// <summary>
        /// Coloca em maiúscula apenas a primeira letra da string.
        /// </summary>
        public static string CapitalizeFirstLetter(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            return char.ToUpper(value[0]) + value[1..];
        }

        /// <summary>
        /// Inverte a ordem dos caracteres na string.
        /// </summary>
        public static string ReverseString(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            var array = value.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}