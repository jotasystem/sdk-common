using JotaSystem.Sdk.Common.Constants;
using JotaSystem.Sdk.Common.Extensions.String;
using JotaSystem.Sdk.Common.Localization;
using JotaSystem.Sdk.Common.Localization.Messages;
using JotaSystem.Sdk.Common.ValueObjects.Base;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;
using System.Text.RegularExpressions;

namespace JotaSystem.Sdk.Common.ValueObjects
{
    public class PhoneValueObject : ValueObjectBase
    {
        public int CountryCode { get; private set; }
        public int AreaCode { get; private set; }
        public string Number { get; private set; } = string.Empty;

        protected PhoneValueObject() { } // EF Core

        public PhoneValueObject(int countryCode, int areaCode, string number, Language? lang = null)
        {
            if (countryCode <= 0)
                throw new ValueObjectException(ValidationMessage.RequiredField(nameof(CountryCode), lang));

            if (areaCode <= 0)
                throw new ValueObjectException(ValidationMessage.RequiredField(nameof(AreaCode), lang));

            if (string.IsNullOrWhiteSpace(number))
                throw new ValueObjectException(ValidationMessage.RequiredField(nameof(Number), lang));

            number = number.OnlyNumbers();

            if (number.Length < Validation.MinPhoneLength)
                throw new ValueObjectException(NumericMessage.MustBeGreaterThan(nameof(Number), Validation.MinPhoneLength, lang));

            if (number.Length > Validation.MaxPhoneLength)
                throw new ValueObjectException(NumericMessage.MustBeLessThan(nameof(Number), Validation.MaxPhoneLength, lang));

            CountryCode = countryCode;
            AreaCode = areaCode;
            Number = number;
        }

        public override string ToString()
        {
            string formatted = Number;

            if (Number.Length >= 8 && Number.Length <= 9)
                formatted = Regex.Replace(Number, @"(\d{4,5})(\d{4})", "$1-$2");

            return $"+{CountryCode} ({AreaCode}) {formatted}";
        }

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return CountryCode;
            yield return AreaCode;
            yield return Number;
        }
    }
}