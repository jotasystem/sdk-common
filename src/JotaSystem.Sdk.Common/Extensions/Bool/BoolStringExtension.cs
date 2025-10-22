namespace JotaSystem.Sdk.Common.Extensions.Bool
{
    /// <summary>
    /// Extensões para interpretação e comparação de strings com valores booleanos.
    /// </summary>
    public static class BoolStringExtension
    {
        /// <summary>
        /// Converte uma string para booleano, aceitando "true/false", "sim/não", "yes/no", "1/0".
        /// </summary>
        /// <param name="value">String a ser convertida.</param>
        /// <returns>Valor booleano correspondente.</returns>
        public static bool ToBool(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            value = value.Trim().ToLowerInvariant();
            return value switch
            {
                "true" or "1" or "yes" or "y" or "sim" or "s" => true,
                "false" or "0" or "no" or "n" or "nao" or "não" => false,
                _ => false
            };
        }

        /// <summary>
        /// Compara semanticamente duas strings que representam booleanos.
        /// </summary>
        /// <param name="value">Primeira string.</param>
        /// <param name="other">Segunda string.</param>
        /// <returns>Retorna <c>true</c> se forem equivalentes como booleanos.</returns>
        public static bool EqualsBool(this string value, string other)
            => value.ToBool() == other.ToBool();
    }
}