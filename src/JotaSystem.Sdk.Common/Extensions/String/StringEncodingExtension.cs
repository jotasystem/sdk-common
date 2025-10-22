using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace JotaSystem.Sdk.Common.Extensions.String
{
    /// <summary> 
    /// Métodos de extensão para codificação, decodificação e hash de strings. 
    /// Inclui Base64, MD5, SHA256 e conversão para ASCII. 
    /// </summary>
    public static class StringEncodingExtension
    {
        /// <summary>
        /// Codifica uma string para Base64.
        /// </summary>
        public static string ToBase64(this string value)
        {
            if (value == null) return string.Empty;
            var bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Decodifica uma string Base64.
        /// </summary>
        public static string FromBase64(this string base64)
        {
            if (string.IsNullOrWhiteSpace(base64)) return string.Empty;
            var bytes = Convert.FromBase64String(base64);
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Remove caracteres acentuados e retorna apenas caracteres ASCII.
        /// </summary>
        public static string ToAscii(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;
            string normalized = value.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (char c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Gera o hash MD5 da string fornecida.
        /// </summary>
        public static string ToMd5(this string value)
        {
            if (value == null) return string.Empty;
            using var md5 = MD5.Create();
            var inputBytes = Encoding.UTF8.GetBytes(value);
            var hashBytes = md5.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }

        /// <summary>
        /// Gera o hash SHA256 da string fornecida.
        /// </summary>
        public static string ToSha256(this string value)
        {
            if (value == null) return string.Empty;
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(value);
            var hash = sha.ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }
}