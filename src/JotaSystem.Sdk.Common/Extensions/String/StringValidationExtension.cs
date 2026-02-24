using JotaSystem.Sdk.Common.Constants;
using System.Globalization;
using System.Text.RegularExpressions;

namespace JotaSystem.Sdk.Common.Extensions.String
{
    /// <summary>
    /// Métodos de extensão para validação de strings.
    /// Inclui verificações para e-mail, URL, número, GUID e outros formatos comuns.
    /// </summary>
    public static class StringValidationExtension
    {
        /// <summary>
        /// Verifica se a string não é nula nem vazia.
        /// </summary>
        public static bool IsNotNullOrEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Verifica se a string não é nula nem composta apenas por espaços em branco.
        /// </summary>
        public static bool IsNotNullOrWhiteSpace(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Verifica se a string é um endereço de e-mail válido.
        /// </summary>
        public static bool IsEmail(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsMatch(value, RegexPatternsConstant.Email, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Verifica se a string representa uma URL válida.
        /// </summary>
        public static bool IsUrl(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return Uri.TryCreate(value, UriKind.Absolute, out var uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        /// <summary>
        /// Verifica se a string contém apenas letras.
        /// </summary>
        public static bool IsAlpha(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            return Regex.IsMatch(value, @"^[a-zA-ZÀ-ÿ]+$");
        }

        /// <summary>
        /// Verifica se a string contém apenas letras e números.
        /// </summary>
        public static bool IsAlphanumeric(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            return Regex.IsMatch(value, @"^[a-zA-Z0-9À-ÿ]+$");
        }

        /// <summary>
        /// Verifica se a string é um número inteiro válido.
        /// </summary>
        public static bool IsInteger(this string value)
        {
            return int.TryParse(value, out _);
        }

        /// <summary>
        /// Verifica se a string é um número decimal válido.
        /// </summary>
        public static bool IsDecimal(this string value)
        {
            return decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
        }

        /// <summary>
        /// Verifica se a string representa um GUID válido.
        /// </summary>
        public static bool IsGuid(this string value)
        {
            return System.Guid.TryParse(value, out _);
        }

        /// <summary>
        /// Verifica se a string é composta apenas por letras maiúsculas.
        /// </summary>
        public static bool IsUpperCase(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            return value.All(char.IsUpper);
        }

        /// <summary>
        /// Verifica se a string é composta apenas por letras minúsculas.
        /// </summary>
        public static bool IsLowerCase(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            return value.All(char.IsLower);
        }
    }
}