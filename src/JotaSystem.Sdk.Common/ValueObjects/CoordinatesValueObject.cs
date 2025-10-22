using JotaSystem.Sdk.Common.Constants;
using JotaSystem.Sdk.Common.Localization;
using JotaSystem.Sdk.Common.Localization.Messages;
using JotaSystem.Sdk.Common.ValueObjects.Base;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;
using JotaSystem.Sdk.Common.Extensions.Number;
using System.Globalization;

namespace JotaSystem.Sdk.Common.ValueObjects
{
    public class CoordinatesValueObject : ValueObjectBase
    {
        public decimal? Latitude { get; private set; }
        public decimal? Longitude { get; private set; }

        protected CoordinatesValueObject() { } // EF Core

        public CoordinatesValueObject(decimal? latitude, decimal? longitude, Language? lang = null)
        {
            if (latitude.HasValue && !latitude.Value.IsBetween(Validation.MinLatitude, Validation.MaxLatitude))
                throw new ValueObjectException(NumericMessage.OutOfRange(nameof(Latitude), Validation.MinLatitude, Validation.MaxLatitude, lang));

            if (longitude.HasValue && !longitude.Value.IsBetween(Validation.MinLongitude, Validation.MaxLongitude))
                throw new ValueObjectException(NumericMessage.OutOfRange(nameof(Longitude), Validation.MinLongitude, Validation.MaxLongitude, lang));

            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString() => string.Format(CultureInfo.InvariantCulture, "{0:F4}, {1:F4}", Latitude, Longitude);

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Latitude;
            yield return Longitude;
        }
    }
}