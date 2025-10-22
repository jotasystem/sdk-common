namespace JotaSystem.Sdk.Common.Extensions.Dictionary
{
    /// <summary>
    /// Extensões para conversão de objetos para dicionário e vice-versa.
    /// </summary>
    public static class DictionaryConversionExtension
    {
        /// <summary>
        /// Converte um objeto em dicionário, usando nomes das propriedades como chave.
        /// </summary>
        public static IDictionary<string, object?> ToDictionary(this object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return obj.GetType()
            .GetProperties()
            .ToDictionary(p => p.Name, p => p.GetValue(obj));
        }

        /// <summary>
        /// Popula um objeto existente a partir de um dicionário de valores.
        /// </summary>
        public static void PopulateFromDictionary<T>(this T obj, IDictionary<string, object?> dict)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (dict == null) throw new ArgumentNullException(nameof(dict));

            var type = obj.GetType();
            foreach (var kv in dict)
            {
                var prop = type.GetProperty(kv.Key);
                if (prop != null && prop.CanWrite)
                {
                    try { prop.SetValue(obj, kv.Value); } catch { /* ignora erros de conversão */ }
                }
            }
        }
    }
}