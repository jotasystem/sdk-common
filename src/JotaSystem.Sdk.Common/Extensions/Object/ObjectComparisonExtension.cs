namespace JotaSystem.Sdk.Common.Extensions.Object
{
    /// <summary>
    /// Fornece métodos de extensão para comparação genérica de objetos.
    /// </summary>
    public static class ObjectComparisonExtension
    {
        /// <summary>
        /// Indica se o objeto é nulo.
        /// </summary>
        public static bool IsNull(this object? obj) => obj is null;

        /// <summary>
        /// Indica se o objeto não é nulo.
        /// </summary>
        public static bool IsNotNull(this object? obj) => obj is not null;

        /// <summary>
        /// Compara dois objetos usando o EqualityComparer padrão.
        /// </summary>
        public static bool IsEqualTo<T>(this T? source, T? other) =>
            EqualityComparer<T?>.Default.Equals(source, other);

        /// <summary>
        /// Indica se o objeto é o valor padrão do tipo.
        /// </summary>
        public static bool IsDefault<T>(this T? value) =>
            EqualityComparer<T?>.Default.Equals(value, default);
    }
}