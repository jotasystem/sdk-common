using JotaSystem.Sdk.Common.Extensions.String;

namespace JotaSystem.Sdk.Common.Helpers
{
    /// <summary>
    /// Helper para operações com emails.
    /// </summary>
    public static class EmailHelper
    {
        /// <summary>
        /// Verifica se um email é válido.
        /// </summary>
        /// <param name="email">Email a ser verificado.</param>
        /// <returns>True se o email é válido; false caso contrário.</returns>
        public static bool IsValidEmail(string email) => email.IsEmail();

        /// <summary>
        /// Retorna o domínio de um email.
        /// </summary>
        /// <param name="email">Email completo.</param>
        /// <returns>Dominio do email (parte após @).</returns>
        public static string GetDomain(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O email não pode ser nulo ou vazio.", nameof(email));

            var parts = email.Split('@');
            if (parts.Length != 2)
                throw new ArgumentException("O email fornecido é inválido.", nameof(email));

            return parts[1];
        }

        /// <summary>
        /// Oculta parte do email, mantendo apenas o início e o domínio.
        /// Ex: joao.silva@example.com → jo*****@example.com
        /// </summary>
        /// <param name="email">Email a ser mascarado.</param>
        /// <returns>Email mascarado.</returns>
        public static string MaskEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O email não pode ser nulo ou vazio.", nameof(email));

            var parts = email.Split('@');
            if (parts.Length != 2)
                throw new ArgumentException("O email fornecido é inválido.", nameof(email));

            var local = parts[0];
            var domain = parts[1];

            if (local.Length <= 2)
                return $"*{local.Substring(local.Length - 1)}@{domain}";

            var visible = local.Substring(0, 2);
            return $"{visible}*****@{domain}";
        }
    }
}