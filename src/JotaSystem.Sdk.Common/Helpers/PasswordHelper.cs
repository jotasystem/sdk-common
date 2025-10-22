using System.Text.RegularExpressions;

namespace JotaSystem.Sdk.Common.Helpers
{
    /// <summary>
    /// Helper para validação de senhas.
    /// Inclui verificações de senhas comuns, sequenciais e força da senha.
    /// </summary>
    public class PasswordHelper
    {
        // Padrões de senhas sequenciais comuns
        private static readonly string SequentialPattern = "123456|abcdef|qwerty|password|654321|098765";

        // Lista de senhas muito comuns
        private static readonly string[] CommonPasswords = { "12345678", "password", "123456789", "qwerty", "12345", "1234567", "letmein", "football", "iloveyou", "admin" };

        /// <summary>
        /// Verifica se a senha contém padrões sequenciais comuns.
        /// </summary>
        /// <param name="password">Senha a ser verificada.</param>
        /// <returns>True se a senha contém sequência; false caso contrário.</returns>
        public static bool IsSequential(string password)
        {
            return Regex.IsMatch(password, SequentialPattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Verifica se a senha está entre as senhas mais comuns.
        /// </summary>
        /// <param name="password">Senha a ser verificada.</param>
        /// <returns>True se a senha é comum; false caso contrário.</returns>
        public static bool IsCommonPassword(string password)
        {
            return CommonPasswords.Contains(password);
        }

        /// <summary>
        /// Verifica se a senha é forte.
        /// Critérios:
        /// - Mínimo 8 caracteres
        /// - Não é sequencial
        /// - Não é comum
        /// - Contém letra maiúscula
        /// - Contém letra minúscula
        /// - Contém número
        /// - Contém caractere especial
        /// </summary>
        /// <param name="password">Senha a ser verificada.</param>
        /// <returns>True se a senha atende a todos os critérios; false caso contrário.</returns>
        public static bool IsStrong(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return false;

            // Exemplo: mínimo 8 caracteres, não sequencial, não comum, inclui letra maiúscula, minúscula, número e caractere especial
            return password.Length >= 8 &&
                   !IsSequential(password) &&
                   !IsCommonPassword(password) &&
                   Regex.IsMatch(password, @"[A-Z]") &&
                   Regex.IsMatch(password, @"[a-z]") &&
                   Regex.IsMatch(password, @"\d") &&
                   Regex.IsMatch(password, @"[\W_]"); // caractere especial
        }
    }
}