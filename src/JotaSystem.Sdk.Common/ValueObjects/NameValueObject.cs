using JotaSystem.Sdk.Common.Constants;
using JotaSystem.Sdk.Common.Localization;
using JotaSystem.Sdk.Common.Localization.Messages;
using JotaSystem.Sdk.Common.ValueObjects.Base;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;

namespace JotaSystem.Sdk.Common.ValueObjects
{
    public class NameValueObject : ValueObjectBase
    {
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;

        protected NameValueObject() { } // EF Core

        public NameValueObject(string firstName, string lastName, Language? lang = null)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ValueObjectException(ValidationMessage.RequiredField(nameof(FirstName), lang));
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ValueObjectException(ValidationMessage.RequiredField(nameof(LastName), lang));

            firstName = firstName.Trim();
            lastName = lastName.Trim();

            if (firstName.Length <= Validation.MinNameLength)
                throw new ValueObjectException(NumericMessage.MustBeGreaterThan(nameof(FirstName), Validation.MinNameLength, lang));
            if (firstName.Length > Validation.MaxNameLength)
                throw new ValueObjectException(NumericMessage.MustBeLessThan(nameof(FirstName), Validation.MaxNameLength, lang));

            if (lastName.Length <= Validation.MinNameLength)
                throw new ValueObjectException(NumericMessage.MustBeGreaterThan(nameof(LastName), Validation.MinNameLength, lang));
            if (lastName.Length > Validation.MaxNameLength)
                throw new ValueObjectException(NumericMessage.MustBeLessThan(nameof(LastName), Validation.MaxNameLength, lang));

            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString() => $"{FirstName} {LastName}";

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}