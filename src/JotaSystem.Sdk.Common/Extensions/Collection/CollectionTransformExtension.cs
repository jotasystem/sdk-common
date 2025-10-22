namespace JotaSystem.Sdk.Common.Extensions.Collection
{
    /// <summary>
    /// Extensões para transformações de coleções.
    /// </summary>
    public static class CollectionTransformExtension
    {
        /// <summary>
        /// Executa uma ação para cada item da coleção.
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            foreach (var item in source)
                action(item);
        }

        /// <summary>
        /// Divide uma coleção em blocos (chunks) de tamanho especificado.
        /// </summary>
        public static IEnumerable<IEnumerable<T>> ChunkSafe<T>(this IEnumerable<T> source, int size)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));

            var chunk = new List<T>(size);
            foreach (var item in source)
            {
                chunk.Add(item);
                if (chunk.Count == size)
                {
                    yield return chunk;
                    chunk = new List<T>(size);
                }
            }
            if (chunk.Count > 0) yield return chunk;
        }

        /// <summary>
        /// Converte a coleção em dicionário de forma segura, ignorando chaves duplicadas.
        /// </summary>
        public static Dictionary<TKey, T> ToDictionarySafe<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector) where TKey : notnull
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var dict = new Dictionary<TKey, T>();

            foreach (var item in source)
            {
                var key = keySelector(item);
                if (key is not null)
                    dict.TryAdd(key, item);
            }

            return dict;
        }

    }
}