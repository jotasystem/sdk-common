namespace JotaSystem.Sdk.Common.Extensions.Enum
{
    /// <summary>
    /// Extensões para conversão de enums, incluindo parse seguro e listagem de valores.
    /// </summary>
    public static class EnumConversionExtension
    {
        /// <summary>
        /// Converte uma string para o tipo enum especificado.
        /// </summary>
        /// <typeparam name="TEnum">Tipo do enum.</typeparam>
        /// <param name="value">Valor textual a ser convertido.</param>
        /// <param name="ignoreCase">Define se a conversão deve ignorar maiúsculas/minúsculas.</param>
        /// <returns>O valor convertido do tipo enum.</returns>
        /// <exception cref="ArgumentException">Lançada se a conversão falhar.</exception>
        public static TEnum ToEnum<TEnum>(this string value, bool ignoreCase = true)
            where TEnum : struct, System.Enum
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("O valor não pode ser nulo ou vazio.", nameof(value));

            if (System.Enum.TryParse(value, ignoreCase, out TEnum result))
                return result;

            throw new ArgumentException($"O valor '{value}' não é válido para o enum {typeof(TEnum).Name}.");
        }

        /// <summary>
        /// Converte uma string para enum, retornando um valor padrão se a conversão falhar.
        /// </summary>
        /// <typeparam name="TEnum">Tipo do enum.</typeparam>
        /// <param name="value">String a ser convertida.</param>
        /// <param name="defaultValue">Valor padrão retornado caso a conversão falhe.</param>
        /// <param name="ignoreCase">Ignorar diferença entre maiúsculas/minúsculas.</param>
        /// <returns>Enum convertido ou valor padrão.</returns>
        public static TEnum ParseOrDefault<TEnum>(this string value, TEnum defaultValue = default, bool ignoreCase = true)
            where TEnum : struct, System.Enum
        {
            if (System.Enum.TryParse(value, ignoreCase, out TEnum result))
                return result;

            return defaultValue;
        }

        /// <summary>
        /// Tenta converter uma string para enum, retornando true se a conversão for bem-sucedida.
        /// </summary>
        /// <typeparam name="TEnum">Tipo do enum.</typeparam>
        /// <param name="value">String a ser convertida.</param>
        /// <param name="result">Enum resultante, caso a conversão seja bem-sucedida.</param>
        /// <returns>True se a conversão foi bem-sucedida, false caso contrário.</returns>
        public static bool TryParseIgnoreCase<TEnum>(this string value, out TEnum result)
            where TEnum : struct, System.Enum
        {
            return System.Enum.TryParse(value, true, out result);
        }

        /// <summary>
        /// Retorna todos os valores possíveis do tipo enum especificado.
        /// </summary>
        /// <typeparam name="TEnum">Tipo do enum.</typeparam>
        /// <returns>Todos os valores do enum.</returns>
        public static IEnumerable<TEnum> GetValues<TEnum>() where TEnum : struct, System.Enum =>
            System.Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

        /// <summary>
        /// Converte o valor do enum para inteiro.
        /// </summary>
        /// <param name="value">Valor do enum.</param>
        /// <returns>Representação inteira do enum.</returns>
        public static int ToInt(this System.Enum value) => Convert.ToInt32(value);
    }
}
