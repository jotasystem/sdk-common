using JotaSystem.Sdk.Common.Constants;
using JotaSystem.Sdk.Common.Localization;
using JotaSystem.Sdk.Common.Localization.Messages;
using JotaSystem.Sdk.Common.ValueObjects.Base;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;
using System.Text.RegularExpressions;

namespace JotaSystem.Sdk.Common.ValueObjects
{
    public class PostalCodeValueObject : ValueObjectBase
    {
        public string PostalCode { get; private set; } = string.Empty;

        protected PostalCodeValueObject() { } // EF Core

        public PostalCodeValueObject(string postalCode, Language? lang = null)
        {
            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ValueObjectException(ValidationMessage.RequiredField(nameof(PostalCode), lang));

            if (!Regex.IsMatch(postalCode, RegexPatterns.Cep))
                throw new ValueObjectException(RegexMessage.InvalidPattern(nameof(PostalCode), lang));

            PostalCode = postalCode;
        }

        public override string ToString() => PostalCode;

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return PostalCode;
        }
    }
}