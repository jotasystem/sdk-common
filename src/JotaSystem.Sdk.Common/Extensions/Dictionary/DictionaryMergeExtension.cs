namespace JotaSystem.Sdk.Common.Extensions.Dictionary
{
    /// <summary>
    /// Extensões para mesclagem de dicionários.
    /// </summary>
    public static class DictionaryMergeExtension
    {
        /// <summary>
        /// Mescla dois dicionários, sobrescrevendo chaves existentes.
        /// </summary>
        public static IDictionary<TKey, TValue> MergeWith<TKey, TValue>(this IDictionary<TKey, TValue> dict, IDictionary<TKey, TValue> other)
        {
            if (dict == null) throw new ArgumentNullException(nameof(dict));
            if (other == null) throw new ArgumentNullException(nameof(other));


            foreach (var kv in other) dict[kv.Key] = kv.Value;
            return dict;
        }
    }
}