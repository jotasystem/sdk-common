namespace JotaSystem.Sdk.Common.Extensions.Number
{
    /// <summary>
    /// Extensões para validações numéricas comuns.
    /// </summary>
    public static class NumberValidationExtension
    {
        /// <summary>
        /// Retorna <c>true</c> se o número for par.
        /// </summary>
        public static bool IsEven(this int value) => value % 2 == 0;

        /// <summary>
        /// Retorna <c>true</c> se o número for ímpar.
        /// </summary>
        public static bool IsOdd(this int value) => value % 2 != 0;

        /// <summary>
        /// Retorna <c>true</c> se o número for primo.
        /// </summary>
        public static bool IsPrime(this int value)
        {
            if (value <= 1) return false;
            if (value == 2) return true;
            if (value % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(value));
            for (int i = 3; i <= boundary; i += 2)
                if (value % i == 0)
                    return false;

            return true;
        }

        /// <summary>
        /// Retorna <c>true</c> se o número estiver dentro do intervalo especificado (inclusive).
        /// </summary>
        public static bool IsBetween<T>(this T value, T min, T max) where T : IComparable<T>
            => value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;

        /// <summary>
        /// Retorna <c>true</c> se o número for múltiplo de outro.
        /// </summary>
        public static bool IsMultipleOf(this int value, int other)
            => other != 0 && value % other == 0;

        /// <summary>
        /// Retorna true se o valor for zero (= 0)
        /// </summary>
        public static bool IsZero<T>(this T number) where T : struct, IComparable<T>
        {
            return number.CompareTo(default) == 0;
        }

        /// <summary>
        /// Retorna true se o valor for positivo (> 0)
        /// </summary>
        public static bool IsPositive<T>(this T number) where T : struct, IComparable<T>
        {
            return number.CompareTo(default) > 0;
        }

        /// <summary>
        /// Retorna true se o valor for negativo (< 0)
        /// </summary>
        public static bool IsNegative<T>(this T number) where T : struct, IComparable<T>
        {
            return number.CompareTo(default) < 0;
        }
    }
}