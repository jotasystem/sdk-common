using JotaSystem.Sdk.Common.Localization.Messages;
using JotaSystem.Sdk.Common.ValueObjects;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;
using Xunit;

namespace JotaSystem.Sdk.Common.Tests.ValueObjects
{
    public class AddressValueObjectTest
    {
        [Fact]
        public void Constructor_ShouldCreate_WhenValidData()
        {
            // Arrange
            var street = "Rua A";
            var number = "123";
            var neighborhood = "Centro";
            var complement = "Apto 4";

            // Act
            var address = new AddressValueObject(street, number, neighborhood, complement);

            // Assert
            Assert.Equal(street, address.Street);
            Assert.Equal(number, address.Number);
            Assert.Equal(neighborhood, address.Neighborhood);
            Assert.Equal(complement, address.Complement);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Constructor_ShouldThrow_WhenStreetIsInvalid(string? street)
        {
            // Act & Assert
            var ex = Assert.Throws<ValueObjectException>(() =>
                new AddressValueObject(street!, "123", "Centro", null));

            Assert.Equal(ValidationMessage.RequiredField(nameof(AddressValueObject.Street)), ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Constructor_ShouldThrow_WhenNumberIsInvalid(string? number)
        {
            // Act & Assert
            var ex = Assert.Throws<ValueObjectException>(() =>
                new AddressValueObject("Rua A", number!, "Centro", null));

            Assert.Equal(ValidationMessage.RequiredField(nameof(AddressValueObject.Number)), ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Constructor_ShouldThrow_WhenNeighborhoodIsInvalid(string? neighborhood)
        {
            // Act & Assert
            var ex = Assert.Throws<ValueObjectException>(() =>
                new AddressValueObject("Rua A", "123", neighborhood!, null));

            Assert.Equal(ValidationMessage.RequiredField(nameof(AddressValueObject.Neighborhood)), ex.Message);
        }

        [Fact]
        public void Constructor_ShouldTrimFields()
        {
            // Arrange
            var street = "  Rua A  ";
            var number = "  123  ";
            var neighborhood = "  Centro  ";

            // Act
            var address = new AddressValueObject(street, number, neighborhood, null);

            // Assert
            Assert.Equal("Rua A", address.Street);
            Assert.Equal("123", address.Number);
            Assert.Equal("Centro", address.Neighborhood);
        }

        [Fact]
        public void ToString_ShouldReturnFormattedAddress()
        {
            // Arrange
            var address = new AddressValueObject("Rua A", "123", "Centro", "Apto 4");

            // Act
            var result = address.ToString();

            // Assert
            Assert.Equal("Rua A, 123 - Apto 4 - Centro", result);
        }

        [Fact]
        public void ToString_ShouldReturnFormattedAddress_WithoutComplement()
        {
            // Arrange
            var address = new AddressValueObject("Rua A", "123", "Centro", null);

            // Act
            var result = address.ToString();

            // Assert
            Assert.Equal("Rua A, 123 - Centro", result);
        }

        [Fact]
        public void Equals_ShouldReturnTrue_WhenAllFieldsAreEqual()
        {
            // Arrange
            var a1 = new AddressValueObject("Rua A", "123", "Centro", "Apto 4");
            var a2 = new AddressValueObject("Rua A", "123", "Centro", "Apto 4");

            // Act
            var areEqual = a1.Equals(a2);
            var hashEqual = a1.GetHashCode() == a2.GetHashCode();

            // Assert
            Assert.True(areEqual);
            Assert.True(hashEqual);
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenFieldsAreDifferent()
        {
            // Arrange
            var a1 = new AddressValueObject("Rua A", "123", "Centro", null);
            var a2 = new AddressValueObject("Rua B", "123", "Centro", null);

            // Act
            var areEqual = a1.Equals(a2);

            // Assert
            Assert.False(areEqual);
        }
    }
}