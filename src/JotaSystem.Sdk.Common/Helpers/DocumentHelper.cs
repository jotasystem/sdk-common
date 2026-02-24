using System.Text.RegularExpressions;

namespace JotaSystem.Sdk.Common.Helpers
{
    /// <summary>
    /// Helper para operações com documentos (cpf, cnpj, etc...)
    /// </summary>
    public static class DocumentHelper
    {
        /// <summary>
        /// Verifica se a string representa um CPF válido (somente números).
        /// </summary>
        public static bool IsValidCpf(string value)
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
        public static bool IsValidCnpj(string cnpj)
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

        /// <summary>
        /// Formata padrão de máscara recebendo um CPF (somente números).
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static string FormatCpf(string cpf)
        {
            if (cpf.Length != 11)
                return cpf;

            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }

        /// <summary>
        /// Formata padrão de máscara recebendo um CNPJ (somente números).
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public static string FormatCnpj(string cnpj)
        {
            if (cnpj.Length != 14)
                return cnpj;

            return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}