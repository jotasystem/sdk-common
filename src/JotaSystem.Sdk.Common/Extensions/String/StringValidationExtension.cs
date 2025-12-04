using JotaSystem.Sdk.Common.Constants;
using System.Globalization;
using System.Text.RegularExpressions;

namespace JotaSystem.Sdk.Common.Extensions.String
{
    /// <summary>
    /// Métodos de extensão para validação de strings.
    /// Inclui verificações para e-mail, URL, número, CPF, CNPJ, GUID e outros formatos comuns.
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

        /// <summary>
        /// Verifica se a string representa um CPF válido (somente números).
        /// </summary>
        public static bool IsCpf(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            var digits = Regex.Replace(value, @"\D", "");
            if (digits.Length != 11 || new string(digits[0], 11) == digits)
                return false;

            int[] mult1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = digits[..9];
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += (tempCpf[i] - '0') * mult1[i];

            int remainder = sum % 11;
            int digit1 = remainder < 2 ? 0 : 11 - remainder;

            tempCpf += digit1;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += (tempCpf[i] - '0') * mult2[i];

            remainder = sum % 11;
            int digit2 = remainder < 2 ? 0 : 11 - remainder;

            return digits.EndsWith($"{digit1}{digit2}");
        }

        /// <summary>
        /// Verifica se a string representa um CNPJ válido (somente números).
        /// </summary>
        public static bool IsCnpj(this string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return false;

            // Remove caracteres não numéricos
            cnpj = Regex.Replace(cnpj, @"\D", "");
            if (cnpj.Length != 14)
                return false;

            // Verifica se todos os números são iguais (inválido)
            if (new string(cnpj[0], 14) == cnpj)
                return false;

            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += (tempCnpj[i] - '0') * multiplicador1[i];

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            tempCnpj += digito1;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += (tempCnpj[i] - '0') * multiplicador2[i];

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            string digitos = $"{digito1}{digito2}";
            return cnpj.EndsWith(digitos);
        }
    }
}