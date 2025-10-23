using JotaSystem.Sdk.Common.Constants;
using JotaSystem.Sdk.Common.Localization.Messages;
using JotaSystem.Sdk.Common.ValueObjects;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;

namespace JotaSystem.Sdk.Common.Tests.ValueObjects
{
    public class CoordinatesValueObjectTest
    {
        [Fact]
        public void Constructor_ShouldCreate_WhenValuesAreWithinRange()
        {
            // Arrange
            decimal latitude = 10.1234m;
            decimal longitude = -20.5678m;

            // Act
            var coord = new CoordinatesValueObject(latitude, longitude);

            // Assert
            Assert.Equal(latitude, coord.Latitude);
            Assert.Equal(longitude, coord.Longitude);
        }

        [Fact]
        public void Constructor_ShouldAllowNullValues()
        {
            // Act
            var coord = new CoordinatesValueObject(null, null);

            // Assert
            Assert.Null(coord.Latitude);
            Assert.Null(coord.Longitude);
        }

        [Theory]
        [InlineData(-91)]
        [InlineData(91)]
        public void Constructor_ShouldThrow_WhenLatitudeOutOfRange(decimal latitude)
        {
            // Act
            var ex = Assert.Throws<ValueObjectException>(() =>
                new CoordinatesValueObject(latitude, 10));

            // Assert
            Assert.Equal(
                NumericMessage.OutOfRange(nameof(CoordinatesValueObject.Latitude),
                    Validation.MinLatitude, Validation.MaxLatitude),
                ex.Message);
        }

        [Theory]
        [InlineData(-181)]
        [InlineData(181)]
        public void Constructor_ShouldThrow_WhenLongitudeOutOfRange(decimal longitude)
        {
            // Act
            var ex = Assert.Throws<ValueObjectException>(() =>
                new CoordinatesValueObject(10, longitude));

            // Assert
            Assert.Equal(
                NumericMessage.OutOfRange(nameof(CoordinatesValueObject.Longitude),
                    Validation.MinLongitude, Validation.MaxLongitude),
                ex.Message);
        }

        [Fact]
        public void ToString_ShouldFormatWithFourDecimalPlaces()
        {
            // Arrange
            var coord = new CoordinatesValueObject(12.34567m, -45.67891m);

            // Act
            var result = coord.ToString();

            // Assert
            Assert.Equal("12.3457, -45.6789", result);
        }

        [Fact]
        public void Equals_ShouldReturnTrue_WhenAllFieldsAreEqual()
        {
            // Arrange
            var c1 = new CoordinatesValueObject(10.1234m, -20.5678m);
            var c2 = new CoordinatesValueObject(10.1234m, -20.5678m);

            // Act
            var areEqual = c1.Equals(c2);
            var hashEqual = c1.GetHashCode() == c2.GetHashCode();

            // Assert
            Assert.True(areEqual);
            Assert.True(hashEqual);
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenFieldsAreDifferent()
        {
            // Arrange
            var c1 = new CoordinatesValueObject(10.1234m, -20.5678m);
            var c2 = new CoordinatesValueObject(10.1234m, 99.9999m);

            // Act
            var areEqual = c1.Equals(c2);

            // Assert
            Assert.False(areEqual);
        }
    }
}