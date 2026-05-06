using JotaSystem.Sdk.Common.Extensions.String;

namespace JotaSystem.Sdk.Common.Helpers
{
    /// <summary>
    /// Helper para normalização e decomposição de telefones.
    /// </summary>
    public static class PhoneHelper
    {
        /// <summary>
        /// Retorna apenas os dígitos do telefone informado.
        /// </summary>
        public static string Normalize(string? phone)
        {
            return (phone ?? string.Empty).OnlyNumbers();
        }

        /// <summary>
        /// Tenta decompor um telefone em código do país, DDD e número.
        /// </summary>
        public static bool TryParse(
            string? phone,
            out (int CountryCode, int AreaCode, string Number) result,
            int defaultCountryCode = 55,
            int areaCodeLength = 2,
            int minLengthWithoutCountryCode = 10)
        {
            result = default;

            if (defaultCountryCode <= 0 || areaCodeLength <= 0 || minLengthWithoutCountryCode <= areaCodeLength)
                return false;

            var digits = Normalize(phone);
            if (string.IsNullOrWhiteSpace(digits))
                return false;

            var countryCodeDigits = defaultCountryCode.ToString();

            if (digits.StartsWith(countryCodeDigits) && digits.Length >= countryCodeDigits.Length + minLengthWithoutCountryCode)
                digits = digits[countryCodeDigits.Length..];

            if (digits.Length < minLengthWithoutCountryCode)
                return false;

            var areaCodeText = digits[..areaCodeLength];
            var number = digits[areaCodeLength..];

            if (!int.TryParse(areaCodeText, out var areaCode) || string.IsNullOrWhiteSpace(number))
                return false;

            result = (defaultCountryCode, areaCode, number);
            return true;
        }

        /// <summary>
        /// Decompõe um telefone em código do país, DDD e número ou lança exceção em caso de formato inválido.
        /// </summary>
        public static (int CountryCode, int AreaCode, string Number) Parse(
            string? phone,
            int defaultCountryCode = 55,
            int areaCodeLength = 2,
            int minLengthWithoutCountryCode = 10,
            string? errorMessage = null)
        {
            if (TryParse(phone, out var result, defaultCountryCode, areaCodeLength, minLengthWithoutCountryCode))
                return result;

            throw new ArgumentException(errorMessage ?? "Telefone inválido.", nameof(phone));
        }
    }
}
