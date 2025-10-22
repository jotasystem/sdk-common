namespace JotaSystem.Sdk.Common.Extensions.Collection
{
    /// <summary>
    /// Extensões para conversões rápidas de coleções.
    /// </summary>
    public static class CollectionConversionExtension
    {
        /// <summary>
        /// Converte a coleção para HashSet.
        /// </summary>
        public static HashSet<T> ToHashSetSafe<T>(this IEnumerable<T>? source)
        {
            return source != null ? new HashSet<T>(source) : new HashSet<T>();
        }

        /// <summary>
        /// Converte a coleção para lista de forma segura, garantindo não nula.
        /// </summary>
        public static List<T> ToListSafe<T>(this IEnumerable<T>? source)
        {
            return source != null ? new List<T>(source) : new List<T>();
        }
    }
}