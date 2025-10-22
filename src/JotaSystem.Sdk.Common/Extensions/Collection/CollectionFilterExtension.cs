namespace JotaSystem.Sdk.Common.Extensions.Collection
{
    /// <summary>
    /// Extensões para filtros e buscas em coleções.
    /// </summary>
    public static class CollectionFilterExtension
    {
        /// <summary>
        /// Aplica o filtro condicionalmente apenas se a condição for verdadeira.
        /// </summary>
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return condition ? source.Where(predicate) : source;
        }

        /// <summary>
        /// Retorna o primeiro elemento ou padrão de forma segura, mesmo que a coleção seja nula.
        /// </summary>
        public static T? FirstOrDefaultSafe<T>(this IEnumerable<T>? source)
        {
            if (source == null) return default;
            return source.FirstOrDefault();
        }

        /// <summary>
        /// Retorna elementos distintos com base em uma chave.
        /// </summary>
        public static IEnumerable<T> DistinctByCustom<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            var seenKeys = new HashSet<TKey>();
            foreach (var element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                    yield return element;
            }
        }
    }
}