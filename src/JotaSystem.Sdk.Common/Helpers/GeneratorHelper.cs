using JotaSystem.Sdk.Common.Constants;
using System.Security.Cryptography;

namespace JotaSystem.Sdk.Common.Helpers
{
    /// <summary>
    /// Helper para geração de códigos aleatórios padronizados.
    /// </summary>
    public static class GeneratorHelper
    {
        /// <summary>
        /// Gera um código aleatório com prefixo.
        /// Exemplo: VND-65GRT9W.
        /// </summary>
        public static string Code(string prefix, int length = 8, string separator = "-", bool useLetters = true, bool useNumbers = true)
        {
            if (string.IsNullOrWhiteSpace(prefix))
                throw new ArgumentException("O prefixo do código é obrigatório.", nameof(prefix));

            if (length <= 0)
                throw new ArgumentException("O tamanho do código deve ser maior que zero.", nameof(length));

            var chars = string.Empty;

            if (useLetters)
                chars += AppConstant.LettersSafe;

            if (useNumbers)
                chars += AppConstant.NumbersSafe;

            if (string.IsNullOrWhiteSpace(chars))
                throw new InvalidOperationException("Nenhum caractere disponível para gerar o código.");

            var value = RandomNumberGenerator.GetString(chars, length);

            return $"{prefix.ToUpperInvariant()}{separator}{value}";
        }

        /// <summary>
        /// Gera um código aleatório apenas com letras.
        /// Exemplo: PDT-XPTO.
        /// </summary>
        public static string CodeLetters(string prefix, int length = 4, string separator = "-")
        {
            return Code(prefix, length, separator, useLetters: true, useNumbers: false);
        }

        /// <summary>
        /// Gera um código aleatório apenas com números.
        /// Exemplo: PED-836492.
        /// </summary>
        public static string CodeNumbers(string prefix, int length = 6, string separator = "-")
        {
            return Code(prefix, length, separator, useLetters: false, useNumbers: true);
        }
    }
}