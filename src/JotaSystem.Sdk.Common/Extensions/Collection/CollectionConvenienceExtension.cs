namespace JotaSystem.Sdk.Common.Extensions.Collection
{
    /// <summary>
    /// Extensões de conveniência para coleções.
    /// </summary>
    public static class CollectionConvenienceExtension
    {
        /// <summary>
        /// Verifica se a coleção é nula ou vazia.
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T>? source)
        {
            return source == null || !source.GetEnumerator().MoveNext();
        }

        /// <summary>
        /// Verifica se a coleção possui itens.
        /// </summary>
        public static bool HasItems<T>(this IEnumerable<T>? source)
        {
            return !source.IsNullOrEmpty();
        }
    }
}