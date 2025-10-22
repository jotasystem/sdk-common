namespace JotaSystem.Sdk.Common.Extensions.Dictionary
{
    /// <summary>
    /// Extensões seguras para operações em dicionários.
    /// </summary>
    public static class DictionarySafeExtension
    {
        /// <summary>
        /// Tenta obter o valor de uma chave, retornando default se não existir.
        /// </summary>
        public static TValue? GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
        {
            if (dict == null) throw new ArgumentNullException(nameof(dict));
            return dict.TryGetValue(key, out var value) ? value : default;
        }

        /// <summary>
        /// Adiciona ou atualiza um valor no dicionário.
        /// </summary>
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (dict == null) throw new ArgumentNullException(nameof(dict));
            dict[key] = value;
        }

        /// <summary>
        /// Tenta remover a chave do dicionário de forma segura.
        /// </summary>
        public static bool TryRemove<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
        {
            if (dict == null) throw new ArgumentNullException(nameof(dict));
            return dict.Remove(key);
        }
    }
}