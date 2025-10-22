namespace JotaSystem.Sdk.Common.Extensions.String
{
    /// <summary>
    /// Métodos de extensão de conveniência para strings.
    /// Inclui operações como valores padrão, truncamento, repetição e substituição condicional.
    /// </summary>
    public static class StringConvenienceExtension
    {
        /// <summary>
        /// Retorna a string original ou um valor padrão caso seja nula ou vazia.
        /// </summary>
        public static string DefaultIfNullOrEmpty(this string value, string defaultValue)
        {
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }

        /// <summary>
        /// Retorna a string original ou um valor padrão caso seja nula ou composta apenas por espaços.
        /// </summary>
        public static string DefaultIfNullOrWhiteSpace(this string value, string defaultValue)
        {
            return string.IsNullOrWhiteSpace(value) ? defaultValue : value;
        }

        /// <summary>
        /// Trunca a string e adiciona "..." se ultrapassar o tamanho máximo especificado.
        /// </summary>
        public static string TruncateWithEllipsis(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value) || maxLength <= 0)
                return string.Empty;

            return value.Length <= maxLength ? value : value[..maxLength] + "...";
        }

        /// <summary>
        /// Repete a string o número de vezes especificado.
        /// </summary>
        public static string Repeat(this string value, int times)
        {
            if (string.IsNullOrEmpty(value) || times <= 0)
                return string.Empty;

            return string.Concat(System.Linq.Enumerable.Repeat(value, times));
        }

        /// <summary>
        /// Retorna a string original ou, se nula, o resultado de uma função fornecida.
        /// </summary>
        public static string IfNullReturn(this string value, System.Func<string> func)
        {
            if (func == null) throw new System.ArgumentNullException(nameof(func));
            return value ?? func();
        }

        /// <summary>
        /// Retorna a string original ou, se vazia, o resultado de uma função fornecida.
        /// </summary>
        public static string IfEmptyReturn(this string value, System.Func<string> func)
        {
            if (func == null) throw new System.ArgumentNullException(nameof(func));
            return string.IsNullOrEmpty(value) ? func() : value;
        }

        /// <summary>
        /// Substitui a string por outra se estiver nula ou vazia.
        /// </summary>
        public static string ReplaceIfNullOrEmpty(this string value, string replacement)
        {
            return string.IsNullOrEmpty(value) ? replacement : value;
        }

        /// <summary>
        /// Converte a string em um array de caracteres.
        /// </summary>
        public static char[] ToCharArraySafe(this string value)
        {
            return string.IsNullOrEmpty(value) ? new char[0] : value.ToCharArray();
        }
    }
}