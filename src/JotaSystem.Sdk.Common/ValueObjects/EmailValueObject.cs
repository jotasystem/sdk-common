using JotaSystem.Sdk.Common.Extensions.String;
using JotaSystem.Sdk.Common.Localization;
using JotaSystem.Sdk.Common.Localization.Messages;
using JotaSystem.Sdk.Common.ValueObjects.Base;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;

namespace JotaSystem.Sdk.Common.ValueObjects
{
    public class EmailValueObject : ValueObjectBase
    {
        public string Email { get; private set; } = string.Empty;

        protected EmailValueObject() { } // EF Core

        public EmailValueObject(string email, Language? lang = null)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ValueObjectException(ValidationMessage.RequiredField(nameof(Email), lang));

            if (!email.Contains('@') || !email.IsEmail())
                throw new ValueObjectException(ValidationMessage.InvalidField(nameof(Email), lang));

            Email = email.Trim().ToLowerInvariant();
        }

        public override string ToString() => Email;

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Email;
        }
    }
}