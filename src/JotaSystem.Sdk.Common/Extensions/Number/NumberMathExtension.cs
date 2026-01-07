using System.Globalization;

namespace JotaSystem.Sdk.Common.Extensions.Number
{
    /// <summary>
    /// Extensões que adicionam operações matemáticas a tipos numéricos.
    /// </summary>
    public static class NumberMathExtension
    {
        /// <summary>
        /// Garante que o número esteja dentro do intervalo especificado (inclusive).
        /// </summary>
        public static T Clamp<T>(this T value, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0) return min;
            if (value.CompareTo(max) > 0) return max;
            return value;
        }

        /// <summary>
        /// Retorna o percentual que o valor representa em relação ao total.
        /// Evita divisão por zero.
        /// Exemplo: 20.PercentFrom(200) => 10
        /// </summary>
        public static decimal PercentFrom(this decimal value, decimal total)
        {
            if (total <= 0)
                return 0;

            return (value / total) * 100m;
        }

        /// <summary>
        /// Retorna o valor percentual com base em um total.
        /// Exemplo: 50.PercentOf(200) => 100
        /// </summary>
        public static decimal PercentOf(this decimal percent, decimal total)
            => (percent / 100m) * total;

        /// <summary>
        /// Retorna o valor aumentado em uma porcentagem.
        /// Exemplo: 100.AddPercent(10) => 110
        /// </summary>
        public static decimal AddPercent(this decimal value, decimal percent)
            => value + (value * percent / 100m);

        /// <summary>
        /// Retorna o valor reduzido em uma porcentagem.
        /// Exemplo: 100.SubtractPercent(10) => 90
        /// </summary>
        public static decimal SubtractPercent(this decimal value, decimal percent)
            => value - (value * percent / 100m);

        /// <summary>
        /// Retorna o valor arredondado para o número de casas decimais informado.
        /// </summary>
        public static decimal RoundTo(this decimal value, int decimals = 2)
            => Math.Round(value, decimals);

        /// <summary>
        /// Retorna o valor absoluto do número.
        /// </summary>
        public static T Abs<T>(this T value) where T : struct, IConvertible
        {
            double val = Math.Abs(value.ToDouble(CultureInfo.InvariantCulture));
            return (T)Convert.ChangeType(val, typeof(T));
        }

        /// <summary>
        /// Retorna o maior entre dois números.
        /// </summary>
        public static T MaxOf<T>(this T value, T other) where T : IComparable<T>
            => value.CompareTo(other) >= 0 ? value : other;

        /// <summary>
        /// Retorna o menor entre dois números.
        /// </summary>
        public static T MinOf<T>(this T value, T other) where T : IComparable<T>
            => value.CompareTo(other) <= 0 ? value : other;
    }
}