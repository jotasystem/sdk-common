using JotaSystem.Sdk.Common.Localization;
using JotaSystem.Sdk.Common.Localization.Messages;
using JotaSystem.Sdk.Common.ValueObjects.Base;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;

namespace JotaSystem.Sdk.Common.ValueObjects
{
    public class AddressValueObject : ValueObjectBase
    {
        public string Street { get; private set; } = string.Empty;
        public string Number { get; private set; } = string.Empty;
        public string Neighborhood { get; private set; } = string.Empty;
        public string? Complement { get; private set; }

        protected AddressValueObject() { } // EF Core

        public AddressValueObject(string street, string number, string neighborhood, string? complement, Language? lang = null)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ValueObjectException(ValidationMessage.RequiredField(nameof(Street), lang));

            if (string.IsNullOrWhiteSpace(number))
                throw new ValueObjectException(ValidationMessage.RequiredField(nameof(Number), lang));

            if (string.IsNullOrWhiteSpace(neighborhood))
                throw new ValueObjectException(ValidationMessage.RequiredField(nameof(Neighborhood), lang));

            Street = street.Trim();
            Number = number.Trim();
            Neighborhood = neighborhood.Trim();
            Complement = complement;
        }

        public override string ToString() => $"{Street}, {Number}{(!string.IsNullOrEmpty(Complement) ? $" - {Complement}" : string.Empty)} - {Neighborhood}";

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Street;
            yield return Number;
            yield return Neighborhood;
            yield return Complement;
        }
    }
}