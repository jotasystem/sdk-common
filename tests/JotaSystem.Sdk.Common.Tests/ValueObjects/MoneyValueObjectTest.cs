using JotaSystem.Sdk.Common.Constants;
using JotaSystem.Sdk.Common.ValueObjects;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;

namespace JotaSystem.Sdk.Common.Tests.ValueObjects
{
    public class MoneyValueObjectTest
    {
        [Fact]
        public void Constructor_ShouldAssignAmountAndCurrency_WhenValid()
        {
            // Arrange
            decimal amount = 123.45m;
            string currency = "USD";

            // Act
            var money = new MoneyValueObject(amount, currency);

            // Assert
            Assert.Equal(amount, money.Amount);
            Assert.Equal(currency, money.Currency);
            Assert.Equal("USD 123.45", money.ToString());
        }

        [Fact]
        public void Constructor_ShouldUseDefaultCurrency_WhenCurrencyIsNullOrEmpty()
        {
            // Arrange
            decimal amount = 50m;

            // Act
            var money1 = new MoneyValueObject(amount, null!);
            var money2 = new MoneyValueObject(amount, "");

            // Assert
            Assert.Equal(AppConstants.DefaultCurrency, money1.Currency);
            Assert.Equal(AppConstants.DefaultCurrency, money2.Currency);
        }

        [Theory]
        [InlineData(-0.01)]
        [InlineData(-100)]
        public void Constructor_ShouldThrow_WhenAmountIsNegative(decimal amount)
        {
            // Act
            var ex = Assert.Throws<ValueObjectException>(() => new MoneyValueObject(amount));

            // Assert
            Assert.Contains("Amount", ex.Message);
        }

        [Fact]
        public void Equals_ShouldReturnTrue_WhenValuesAreSame()
        {
            // Arrange
            var m1 = new MoneyValueObject(100m, "BRL");
            var m2 = new MoneyValueObject(100m, "BRL");

            // Act & Assert
            Assert.Equal(m1, m2);
            Assert.True(m1.GetHashCode() == m2.GetHashCode());
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenAmountIsDifferent()
        {
            // Arrange
            var m1 = new MoneyValueObject(100m, "BRL");
            var m2 = new MoneyValueObject(200m, "BRL");

            // Act & Assert
            Assert.NotEqual(m1, m2);
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenCurrencyIsDifferent()
        {
            // Arrange
            var m1 = new MoneyValueObject(100m, "BRL");
            var m2 = new MoneyValueObject(100m, "USD");

            // Act & Assert
            Assert.NotEqual(m1, m2);
        }
    }
}