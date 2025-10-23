using JotaSystem.Sdk.Common.Constants;
using JotaSystem.Sdk.Common.Extensions.Number;
using JotaSystem.Sdk.Common.Localization;
using JotaSystem.Sdk.Common.Localization.Messages;
using JotaSystem.Sdk.Common.ValueObjects.Base;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;
using System.Globalization;

namespace JotaSystem.Sdk.Common.ValueObjects
{
    public class MoneyValueObject : ValueObjectBase
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; } = string.Empty;

        protected MoneyValueObject() { } // EF Core

        public MoneyValueObject(decimal amount, string currency = AppConstants.DefaultCurrency, Language? lang = null)
        {
            if (amount.IsNegative())
                throw new ValueObjectException(NumericMessage.MustBePositive(nameof(Amount), lang));

            Amount = amount;
            Currency = string.IsNullOrWhiteSpace(currency) ? AppConstants.DefaultCurrency : currency.Trim().ToUpperInvariant();
        }

        public override string ToString() => $"{Currency} {Amount.ToString("F2", CultureInfo.InvariantCulture)}";

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}