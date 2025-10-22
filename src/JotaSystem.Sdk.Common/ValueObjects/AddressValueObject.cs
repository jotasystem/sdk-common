using JotaSystem.Sdk.Common.ValueObjects.Base;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;

namespace JotaSystem.Sdk.Common.ValueObjects
{
    public class AddressValueObject : ValueObjectBase
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string? Complement { get; private set; }

        public AddressValueObject(string street, string number, string neighborhood, string? complement)
        {
            if (string.IsNullOrEmpty(street))
                throw new ValueObjectException("Street não pode ser vazio.");

            if (string.IsNullOrEmpty(number))
                throw new ValueObjectException("Number não pode ser vazio.");

            if (string.IsNullOrEmpty(neighborhood))
                throw new ValueObjectException("Neighborhood não pode ser vazio.");

            Street = street.Trim();
            Number = number.Trim();
            Neighborhood = neighborhood.Trim();
            Complement = complement;
        }

        public override string ToString() => $"{Street}, {Number}{(!string.IsNullOrEmpty(Complement) ? $" - {Complement}" : null)} - {Neighborhood}";

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Street;
            yield return Number;
            yield return Neighborhood;
            yield return Complement;
        }
    }
}