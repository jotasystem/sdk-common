using JotaSystem.Sdk.Common.ValueObjects;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;
using Xunit;

namespace JotaSystem.Sdk.Common.Tests.ValueObjects
{
    public class PhoneValueObjectTests
    {
        [Fact]
        public void Constructor_ShouldAssignValues_WhenValid()
        {
            var vo = new PhoneValueObject(55, 11, "987654321");

            Assert.Equal(55, vo.CountryCode);
            Assert.Equal(11, vo.AreaCode);
            Assert.Equal("987654321", vo.Number);
            Assert.Equal("+55 (11) 98765-4321", vo.ToString());
        }

        [Theory]
        [InlineData(0, 11, "987654321", "CountryCode")]
        [InlineData(-1, 11, "987654321", "CountryCode")]
        [InlineData(55, 0, "987654321", "AreaCode")]
        [InlineData(55, -1, "987654321", "AreaCode")]
        [InlineData(55, 11, "", "Number")]
        [InlineData(55, 11, null, "Number")]
        public void Constructor_ShouldThrow_WhenInvalidValues(int country, int area, string? number, string expectedField)
        {
            var ex = Assert.Throws<ValueObjectException>(() => new PhoneValueObject(country, area!, number!));
            Assert.Contains(expectedField, ex.Message);
        }

        [Theory]
        [InlineData("1234567")] // too short
        [InlineData("123456789012123")] // too long
        public void Constructor_ShouldThrow_WhenNumberLengthInvalid(string number)
        {
            var ex = Assert.Throws<ValueObjectException>(() => new PhoneValueObject(55, 11, number));
            Assert.Contains("Number", ex.Message);
        }

        [Fact]
        public void Equals_ShouldReturnTrue_WhenPhonesAreSame()
        {
            var p1 = new PhoneValueObject(55, 11, "987654321");
            var p2 = new PhoneValueObject(55, 11, "987654321");

            Assert.Equal(p1, p2);
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenPhonesAreDifferent()
        {
            var p1 = new PhoneValueObject(55, 11, "987654321");
            var p2 = new PhoneValueObject(55, 11, "987654322");

            Assert.NotEqual(p1, p2);
        }
    }
}