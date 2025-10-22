namespace JotaSystem.Sdk.Common.Extensions.Collection
{
    /// <summary>
    /// Extensões para ordenação de coleções.
    /// </summary>
    public static class CollectionOrderExtension
    {
        /// <summary>
        /// Ordena a coleção de forma segura por uma chave.
        /// </summary>
        public static IEnumerable<T> OrderBySafe<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            if (source == null) return Enumerable.Empty<T>();
            return source.OrderBy(keySelector);
        }

        /// <summary>
        /// Ordena a coleção de forma decrescente por uma chave.
        /// </summary>
        public static IEnumerable<T> OrderByDescendingSafe<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            if (source == null) return Enumerable.Empty<T>();
            return source.OrderByDescending(keySelector);
        }
    }
}