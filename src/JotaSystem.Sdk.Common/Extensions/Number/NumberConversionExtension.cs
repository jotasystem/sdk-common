using System.Globalization;

namespace JotaSystem.Sdk.Common.Extensions.Number
{
    /// <summary>
    /// Extensões para conversão segura entre tipos numéricos.
    /// </summary>
    public static class NumberConversionExtension
    {
        /// <summary>
        /// Tenta converter um texto em inteiro, retornando valor padrão se falhar.
        /// </summary>
        public static int ToIntSafe(this string? value, int defaultValue = 0)
            => int.TryParse(value, out var result) ? result : defaultValue;

        /// <summary>
        /// Tenta converter um texto em decimal, retornando valor padrão se falhar.
        /// </summary>
        public static decimal ToDecimalSafe(this string? value, decimal defaultValue = 0)
            => decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var result) ? result : defaultValue;

        /// <summary>
        /// Converte um valor decimal para double.
        /// </summary>
        public static double ToDouble(this decimal value)
            => Convert.ToDouble(value);

        /// <summary>
        /// Converte um valor double para decimal.
        /// </summary>
        public static decimal ToDecimal(this double value)
            => Convert.ToDecimal(value);
    }
}