namespace JotaSystem.Sdk.Common.Extensions.Object
{
    /// <summary>
    /// Fornece métodos de extensão para conversão genérica de objetos.
    /// </summary>
    public static class ObjectConversionExtension
    {
        /// <summary>
        /// Tenta converter o objeto para o tipo especificado.
        /// Retorna o valor convertido ou o padrão caso a conversão falhe.
        /// </summary>
        public static T? ToOrDefault<T>(this object? value)
        {
            try
            {
                if (value == null) return default;
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return default;
            }
        }

        /// <summary>
        /// Tenta realizar um cast para o tipo especificado, retornando default em caso de falha.
        /// Compatível com tipos valor e referência.
        /// </summary>
        public static T? TryCast<T>(this object? value)
        {
            if (value is null) return default;
            return value is T variable ? variable : default;
        }

        /// <summary>
        /// Cria uma cópia profunda do objeto via serialização binária.
        /// </summary>
        public static T? DeepClone<T>(this T? obj)
        {
            if (obj is null) return default;
            var json = System.Text.Json.JsonSerializer.Serialize(obj);
            return System.Text.Json.JsonSerializer.Deserialize<T>(json);
        }
    }
}