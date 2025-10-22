namespace JotaSystem.Sdk.Common.Extensions.String
{
    /// <summary>
    /// Métodos de extensão voltados à busca, substituição e localização de padrões dentro de strings.
    /// </summary>
    public static class StringSearchExtension
    {
        /// <summary>
        /// Substitui apenas a primeira ocorrência de um valor específico.
        /// </summary>
        public static string ReplaceFirst(this string value, string oldValue, string newValue)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(oldValue))
                return value ?? string.Empty;

            int pos = value.IndexOf(oldValue);
            if (pos < 0) return value;

            return value[..pos] + newValue + value[(pos + oldValue.Length)..];
        }

        /// <summary>
        /// Substitui apenas a última ocorrência de um valor específico.
        /// </summary>
        public static string ReplaceLast(this string value, string oldValue, string newValue)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(oldValue))
                return value ?? string.Empty;

            int pos = value.LastIndexOf(oldValue);
            if (pos < 0) return value;

            return value[..pos] + newValue + value[(pos + oldValue.Length)..];
        }

        /// <summary>
        /// Remove todas as ocorrências das strings especificadas.
        /// </summary>
        public static string RemoveAll(this string value, params string[] values)
        {
            if (string.IsNullOrEmpty(value) || values == null || values.Length == 0)
                return value ?? string.Empty;

            string result = value;
            foreach (var v in values)
                result = result.Replace(v, string.Empty);

            return result;
        }

        /// <summary>
        /// Retorna o índice da n-ésima ocorrência de uma substring.
        /// Retorna -1 se não encontrada.
        /// </summary>
        public static int IndexOfNth(this string value, string substring, int occurrence)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(substring) || occurrence <= 0)
                return -1;

            int index = -1;
            for (int i = 0; i < occurrence; i++)
            {
                index = value.IndexOf(substring, index + 1, StringComparison.Ordinal);
                if (index == -1)
                    return -1;
            }
            return index;
        }

        /// <summary>
        /// Verifica se a string começa com um valor, ignorando diferenciação de maiúsculas/minúsculas.
        /// </summary>
        public static bool StartsWithIgnoreCase(this string value, string comparison)
        {
            if (value == null || comparison == null) return false;
            return value.StartsWith(comparison, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Verifica se a string termina com um valor, ignorando diferenciação de maiúsculas/minúsculas.
        /// </summary>
        public static bool EndsWithIgnoreCase(this string value, string comparison)
        {
            if (value == null || comparison == null) return false;
            return value.EndsWith(comparison, StringComparison.OrdinalIgnoreCase);
        }
    }
}