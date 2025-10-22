using JotaSystem.Sdk.Common.Constants;
using JotaSystem.Sdk.Common.Helpers;
using JotaSystem.Sdk.Common.Localization;
using JotaSystem.Sdk.Common.Localization.Messages;
using JotaSystem.Sdk.Common.ValueObjects.Base;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;

namespace JotaSystem.Sdk.Common.ValueObjects
{
    public class PasswordValueObject : ValueObjectBase
    {
        public string Password { get; private set; } = string.Empty;

        protected PasswordValueObject() { } // EF Core

        public PasswordValueObject(string password, Language? lang = null)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ValueObjectException(ValidationMessage.RequiredField(nameof(Password), lang));

            if (password.Length <= Validation.MinPasswordLength)
                throw new ValueObjectException(NumericMessage.MustBeGreaterThan(nameof(Password), Validation.MinPasswordLength, lang));
            if (password.Length > Validation.MaxPasswordLength)
                throw new ValueObjectException(NumericMessage.MustBeLessThan(nameof(Password), Validation.MaxPasswordLength, lang));

            if (!PasswordHelper.IsStrong(password))
                throw new ValueObjectException(RegexMessage.InvalidPattern(nameof(Password), lang));

            Password = password;
        }

        public override string ToString() => Password;

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Password;
        }
    }
}