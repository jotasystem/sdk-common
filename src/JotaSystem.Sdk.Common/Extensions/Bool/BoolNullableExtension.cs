namespace JotaSystem.Sdk.Common.Extensions.Bool
{
    /// <summary>
    /// Extensões para manipulação de valores booleanos nulos (<see cref="bool?"/>).
    /// </summary>
    public static class BoolNullableExtension
    {
        /// <summary>
        /// Retorna o valor do booleano nulo ou um valor padrão caso seja null.
        /// </summary>
        /// <param name="value">Valor nulo.</param>
        /// <param name="defaultValue">Valor padrão retornado se nulo.</param>
        /// <returns>Valor real ou padrão.</returns>
        public static bool GetValueOrDefault(this bool? value, bool defaultValue = false)
            => value ?? defaultValue;

        /// <summary>
        /// Retorna <c>true</c> se o valor for true.
        /// </summary>
        public static bool IsTrue(this bool? value)
            => value.HasValue && value.Value;

        /// <summary>
        /// Retorna <c>true</c> se o valor for false.
        /// </summary>
        public static bool IsFalse(this bool? value)
            => value.HasValue && !value.Value;
    }
}