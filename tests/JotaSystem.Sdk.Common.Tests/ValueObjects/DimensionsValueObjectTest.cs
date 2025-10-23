using JotaSystem.Sdk.Common.Constants;
using JotaSystem.Sdk.Common.Localization.Messages;
using JotaSystem.Sdk.Common.ValueObjects;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;

namespace JotaSystem.Sdk.Common.Tests.ValueObjects
{
    public class DimensionsValueObjectTest
    {
        [Fact]
        public void Constructor_ShouldCreate_WhenValuesAreValid()
        {
            // Arrange
            decimal weight = 5m;
            decimal width = 20m;
            decimal height = 30m;
            decimal length = 40m;

            // Act
            var dim = new DimensionsValueObject(weight, width, height, length);

            // Assert
            Assert.Equal(weight, dim.WeightKg);
            Assert.Equal(width, dim.WidthCm);
            Assert.Equal(height, dim.HeightCm);
            Assert.Equal(length, dim.LengthCm);
        }

        [Fact]
        public void Constructor_ShouldAllowNullValues()
        {
            // Act
            var dim = new DimensionsValueObject(null, null, null, null);

            // Assert
            Assert.Null(dim.WeightKg);
            Assert.Null(dim.WidthCm);
            Assert.Null(dim.HeightCm);
            Assert.Null(dim.LengthCm);
        }

        [Fact]
        public void Constructor_ShouldThrow_WhenWeightBelowMin()
        {
            // Act
            var ex = Assert.Throws<ValueObjectException>(() =>
                new DimensionsValueObject(Validation.MinWeightKg, 10, 10, 10));

            // Assert
            Assert.Equal(
                NumericMessage.MustBeGreaterThan(nameof(DimensionsValueObject.WeightKg), Validation.MinWeightKg),
                ex.Message);
        }

        [Fact]
        public void Constructor_ShouldThrow_WhenWeightAboveMax()
        {
            // Act
            var ex = Assert.Throws<ValueObjectException>(() =>
                new DimensionsValueObject(Validation.MaxWeightKg + 1, 10, 10, 10));

            // Assert
            Assert.Equal(
                NumericMessage.MustBeLessThan(nameof(DimensionsValueObject.WeightKg), Validation.MaxWeightKg),
                ex.Message);
        }

        [Fact]
        public void Constructor_ShouldThrow_WhenWidthBelowMin()
        {
            // Act
            var ex = Assert.Throws<ValueObjectException>(() =>
                new DimensionsValueObject(10, Validation.MinWidthCm, 10, 10));

            // Assert
            Assert.Equal(
                NumericMessage.MustBeGreaterThan(nameof(DimensionsValueObject.WidthCm), Validation.MinWidthCm),
                ex.Message);
        }

        [Fact]
        public void Constructor_ShouldThrow_WhenWidthAboveMax()
        {
            // Act
            var ex = Assert.Throws<ValueObjectException>(() =>
                new DimensionsValueObject(10, Validation.MaxWidthCm + 1, 10, 10));

            // Assert
            Assert.Equal(
                NumericMessage.MustBeLessThan(nameof(DimensionsValueObject.WidthCm), Validation.MaxWidthCm),
                ex.Message);
        }

        [Fact]
        public void Constructor_ShouldThrow_WhenHeightBelowMin()
        {
            // Act
            var ex = Assert.Throws<ValueObjectException>(() =>
                new DimensionsValueObject(10, 10, Validation.MinHeightCm, 10));

            // Assert
            Assert.Equal(
                NumericMessage.MustBeGreaterThan(nameof(DimensionsValueObject.HeightCm), Validation.MinHeightCm),
                ex.Message);
        }

        [Fact]
        public void Constructor_ShouldThrow_WhenHeightAboveMax()
        {
            // Act
            var ex = Assert.Throws<ValueObjectException>(() =>
                new DimensionsValueObject(10, 10, Validation.MaxHeightCm + 1, 10));

            // Assert
            Assert.Equal(
                NumericMessage.MustBeLessThan(nameof(DimensionsValueObject.HeightCm), Validation.MaxHeightCm),
                ex.Message);
        }

        [Fact]
        public void Constructor_ShouldThrow_WhenLengthBelowMin()
        {
            // Act
            var ex = Assert.Throws<ValueObjectException>(() =>
                new DimensionsValueObject(10, 10, 10, Validation.MinLengthCm));

            // Assert
            Assert.Equal(
                NumericMessage.MustBeGreaterThan(nameof(DimensionsValueObject.LengthCm), Validation.MinLengthCm),
                ex.Message);
        }

        [Fact]
        public void Constructor_ShouldThrow_WhenLengthAboveMax()
        {
            // Act
            var ex = Assert.Throws<ValueObjectException>(() =>
                new DimensionsValueObject(10, 10, 10, Validation.MaxLengthCm + 1));

            // Assert
            Assert.Equal(
                NumericMessage.MustBeLessThan(nameof(DimensionsValueObject.LengthCm), Validation.MaxLengthCm),
                ex.Message);
        }

        [Fact]
        public void ToString_ShouldReturnFormattedDimensions_WhenAllValuesProvided()
        {
            // Arrange
            var dim = new DimensionsValueObject(5m, 20m, 30m, 40m);

            // Act
            var result = dim.ToString();

            // Assert
            Assert.Equal("5 kg, 20x30x40 cm", result);
        }

        [Fact]
        public void ToString_ShouldReturnFormattedDimensions_WhenSomeValuesNull()
        {
            // Arrange
            var dim = new DimensionsValueObject(null, 20m, 30m, null);

            // Act
            var result = dim.ToString();

            // Assert
            Assert.Equal("20x30 cm", result);
        }

        [Fact]
        public void ToString_ShouldReturnEmpty_WhenAllValuesNull()
        {
            // Arrange
            var dim = new DimensionsValueObject(null, null, null, null);

            // Act
            var result = dim.ToString();

            // Assert
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void Equals_ShouldReturnTrue_WhenAllFieldsAreEqual()
        {
            // Arrange
            var d1 = new DimensionsValueObject(5, 20, 30, 40);
            var d2 = new DimensionsValueObject(5, 20, 30, 40);

            // Act
            var areEqual = d1.Equals(d2);
            var hashEqual = d1.GetHashCode() == d2.GetHashCode();

            // Assert
            Assert.True(areEqual);
            Assert.True(hashEqual);
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenFieldsAreDifferent()
        {
            // Arrange
            var d1 = new DimensionsValueObject(5, 20, 30, 40);
            var d2 = new DimensionsValueObject(5, 20, 30, 50);

            // Act
            var areEqual = d1.Equals(d2);

            // Assert
            Assert.False(areEqual);
        }
    }
}