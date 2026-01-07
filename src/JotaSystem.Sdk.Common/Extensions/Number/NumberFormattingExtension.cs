using System.Globalization;

namespace JotaSystem.Sdk.Common.Extensions.Number
{
    public static class NumberFormattingExtension
    {
        /// <summary>
        /// Retorna uma string formatada no padrão monetário da cultura informada (padrão: pt-BR).
        /// </summary>
        public static string ToCurrency(this decimal value, string? culture = "pt-BR")
            => string.Format(new CultureInfo(culture ?? "pt-BR"), "{0:C}", value);

        /// <summary>
        /// Retorna uma string formatada no padrão monetário da cultura informada, exibindo o sinal (+ e -).
        /// </summary>
        public static string ToCurrencyWithSign(this decimal value, string? culture = "pt-BR")
        {
            var cultureInfo = new CultureInfo(culture ?? "pt-BR");
            var sign = value > 0 ? "+" : value < 0 ? "-" : string.Empty;
            var formattedValue = Math.Abs(value).ToString("C", cultureInfo);
            return $"{sign} {formattedValue}";
        }

        /// <summary>
        /// Retorna uma string formatada com separadores de milhar e casas decimais.
        /// </summary>
        public static string ToFormattedString(this double value, int decimalPlaces = 2, string? culture = "pt-BR")
        {
            var format = "N" + decimalPlaces;
            return value.ToString(format, new CultureInfo(culture ?? "pt-BR"));
        }

        /// <summary>
        /// Retorna uma string formatada com separadores de milhar e casas decimais, exibindo o sinal (+ e -).
        /// </summary>
        public static string ToFormattedStringWithSign( this double value, int decimalPlaces = 2, string? culture = "pt-BR")
        {
            var cultureInfo = new CultureInfo(culture ?? "pt-BR");
            var format = "N" + decimalPlaces;
            var sign = value > 0 ? "+" : value < 0 ? "-" : string.Empty;

            var formattedValue = Math.Abs(value).ToString(format, cultureInfo);
            return $"{sign}{formattedValue}";
        }

        /// <summary>
        /// Retorna uma string formatada com o percentual (ex: 10.50%).
        /// </summary>
        public static string ToPercent(this decimal value, int decimals = 2, string culture = "pt-BR")
        {
            return value.ToString($"F{decimals}", CultureInfo.GetCultureInfo(culture)) + "%";
        }

        /// <summary>
        /// Retorna uma string percentual formatada com sinal explícito (+ ou -).
        /// </summary>
        public static string ToPercentWithSign(this decimal value, int decimals = 2, string culture = "pt-BR")
        {
            var cultureInfo = CultureInfo.GetCultureInfo(culture);
            var format = $"+0.{new string('0', decimals)};-0.{new string('0', decimals)}";
            return value.ToString(format, cultureInfo) + "%";
        }

        /// <summary>
        /// Retorna a representação ordinal do número (exemplo: 1º, 2º, 3º...).
        /// </summary>
        public static string ToOrdinal(this int value)
        {
            if (value <= 0)
                return value.ToString();

            return $"{value}º";
        }

        /// <summary>
        /// Retorna o número abreviado (exemplo: 1.2K, 3.4M, 5B).
        /// </summary>
        public static string ToAbbreviated(this double value, int decimalPlaces = 1)
        {
            string suffix;
            double shortValue;

            if (value >= 1_000_000_000)
            {
                shortValue = value / 1_000_000_000;
                suffix = "B";
            }
            else if (value >= 1_000_000)
            {
                shortValue = value / 1_000_000;
                suffix = "M";
            }
            else if (value >= 1_000)
            {
                shortValue = value / 1_000;
                suffix = "K";
            }
            else
            {
                shortValue = value;
                suffix = "";
            }

            return shortValue.ToString($"F{decimalPlaces}", CultureInfo.InvariantCulture) + suffix;
        }
    }
}
