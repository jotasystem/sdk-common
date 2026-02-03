using System;
using System.Collections.Generic;
using System.Text;

namespace JotaSystem.Sdk.Common.Helpers
{
    /// <summary>
    /// Utilitário para ofuscação de dados sensíveis (LGPD).
    /// Não usar para formatação ou persistência.
    /// </summary>
    public static class PrivacyHelper
    {
        private const char DefaultMaskChar = '•';

        #region Email

        /// <summary>
        /// Ex: joao.silva@email.com → j•••••••••a@email.com
        /// </summary>
        public static string MaskEmail(string? email, char maskChar = DefaultMaskChar)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
                return email ?? string.Empty;

            var atIndex = email.IndexOf('@');
            var local = email[..atIndex];
            var domain = email[atIndex..];

            if (local.Length <= 2)
                return email;

            var sb = new StringBuilder();
            sb.Append(local[0]);

            sb.Append(new string(maskChar, local.Length - 2));

            sb.Append(local[^1]);
            sb.Append(domain);

            return sb.ToString();
        }

        #endregion

        #region Telefone

        /// <summary>
        /// Ex: (11) 98765-4321 → (11) •••••-4321
        /// </summary>
        public static string MaskPhone(string? phone, char maskChar = DefaultMaskChar)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return phone ?? string.Empty;

            var sb = new StringBuilder(phone);

            for (int i = 0; i < phone.Length; i++)
            {
                if (char.IsDigit(phone[i]))
                {
                    // mantém os 4 últimos dígitos
                    if (CountDigitsAfter(phone, i) > 4)
                        sb[i] = maskChar;
                }
            }

            return sb.ToString();
        }

        private static int CountDigitsAfter(string text, int index)
        {
            int count = 0;

            for (int i = index; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                    count++;
            }

            return count;
        }

        #endregion

        #region CPF / CNPJ

        /// <summary>
        /// CPF: 123.456.789-01 → 123.•••.•••-01
        /// </summary>
        public static string MaskCpf(string? cpf, char maskChar = DefaultMaskChar)
        {
            return MaskKeepingStartAndEnd(cpf, 3, 2, maskChar);
        }

        /// <summary>
        /// CNPJ: 12.345.678/0001-99 → 12.•••.•••/••••-99
        /// </summary>
        public static string MaskCnpj(string? cnpj, char maskChar = DefaultMaskChar)
        {
            return MaskKeepingStartAndEnd(cnpj, 2, 2, maskChar);
        }

        #endregion

        #region Genérico

        /// <summary>
        /// Mantém X caracteres no início e Y no final, mascarando o resto
        /// </summary>
        public static string MaskKeepingStartAndEnd(
            string? value,
            int keepStart,
            int keepEnd,
            char maskChar = DefaultMaskChar)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value ?? string.Empty;

            var sb = new StringBuilder(value.Length);
            int length = value.Length;

            for (int i = 0; i < length; i++)
            {
                if (i < keepStart || i >= length - keepEnd)
                    sb.Append(value[i]);
                else if (!char.IsWhiteSpace(value[i]))
                    sb.Append(maskChar);
                else
                    sb.Append(value[i]);
            }

            return sb.ToString();
        }

        #endregion

        #region Nome / Texto livre

        /// <summary>
        /// Ex: João da Silva → J••• d• S••••
        /// </summary>
        public static string MaskName(string? name, char maskChar = DefaultMaskChar)
        {
            if (string.IsNullOrWhiteSpace(name))
                return name ?? string.Empty;

            var parts = name.Split(' ');

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Length <= 2)
                    continue;

                parts[i] = parts[i][0]
                           + new string(maskChar, parts[i].Length - 1);
            }

            return string.Join(' ', parts);
        }

        #endregion
    }
}