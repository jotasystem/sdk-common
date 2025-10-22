using JotaSystem.Sdk.Common.Constants;
using JotaSystem.Sdk.Common.Localization;
using JotaSystem.Sdk.Common.Localization.Messages;
using JotaSystem.Sdk.Common.ValueObjects.Base;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;

namespace JotaSystem.Sdk.Common.ValueObjects
{
    public class DimensionsValueObject : ValueObjectBase
    {
        public decimal? WeightKg { get; private set; }
        public decimal? WidthCm { get; private set; }
        public decimal? HeightCm { get; private set; }
        public decimal? LengthCm { get; private set; }

        protected DimensionsValueObject() { } // EF Core

        public DimensionsValueObject(decimal? weightKg, decimal? widthCm, decimal? heightCm, decimal? lengthCm, Language? lang = null)
        {
            if (weightKg.HasValue)
            {
                if (weightKg <= Validation.MinWeightKg)
                    throw new ValueObjectException(NumericMessage.MustBeGreaterThan(nameof(WeightKg), Validation.MinWeightKg, lang));
                if (weightKg > Validation.MaxWeightKg)
                    throw new ValueObjectException(NumericMessage.MustBeLessThan(nameof(WeightKg), Validation.MaxWeightKg, lang));
            }

            if (widthCm.HasValue)
            {
                if (widthCm <= Validation.MinWidthCm)
                    throw new ValueObjectException(NumericMessage.MustBeGreaterThan(nameof(WidthCm), Validation.MinWidthCm, lang));
                if (widthCm > Validation.MaxWidthCm)
                    throw new ValueObjectException(NumericMessage.MustBeLessThan(nameof(WidthCm), Validation.MaxWidthCm, lang));
            }

            if (heightCm.HasValue)
            {
                if (heightCm <= Validation.MinHeightCm)
                    throw new ValueObjectException(NumericMessage.MustBeGreaterThan(nameof(HeightCm), Validation.MinHeightCm, lang));
                if (heightCm > Validation.MaxHeightCm)
                    throw new ValueObjectException(NumericMessage.MustBeLessThan(nameof(HeightCm), Validation.MaxHeightCm, lang));
            }

            if (lengthCm.HasValue)
            {
                if (lengthCm <= Validation.MinLengthCm)
                    throw new ValueObjectException(NumericMessage.MustBeGreaterThan(nameof(LengthCm), Validation.MinLengthCm, lang));
                if (lengthCm > Validation.MaxLengthCm)
                    throw new ValueObjectException(NumericMessage.MustBeLessThan(nameof(LengthCm), Validation.MaxLengthCm, lang));
            }

            WeightKg = weightKg;
            WidthCm = widthCm;
            HeightCm = heightCm;
            LengthCm = lengthCm;
        }

        public override string ToString()
        {
            var parts = new List<string>();

            if (WeightKg.HasValue)
                parts.Add($"{WeightKg.Value} kg");

            var dims = new List<string>();
            if (WidthCm.HasValue) dims.Add(WidthCm.Value.ToString());
            if (HeightCm.HasValue) dims.Add(HeightCm.Value.ToString());
            if (LengthCm.HasValue) dims.Add(LengthCm.Value.ToString());

            if (dims.Count != 0)
                parts.Add(string.Join("x", dims) + " cm");

            return string.Join(", ", parts);
        }

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return WeightKg;
            yield return WidthCm;
            yield return HeightCm;
            yield return LengthCm;
        }
    }
}
