using JotaSystem.Sdk.Common.ValueObjects;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;

namespace JotaSystem.Sdk.Common.Tests.ValueObjects
{
    public class PostalCodeValueObjectTests
    {
        [Theory]
        [InlineData("12345-678")]
        [InlineData("01001-000")]
        public void Constructor_ShouldAssignPostalCode_WhenValid(string validPostalCode)
        {
            var vo = new PostalCodeValueObject(validPostalCode);

            Assert.Equal(validPostalCode, vo.PostalCode);
            Assert.Equal(validPostalCode, vo.ToString());
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Constructor_ShouldThrow_WhenPostalCodeIsNullOrWhitespace(string? postalCode)
        {
            var ex = Assert.Throws<ValueObjectException>(() => new PostalCodeValueObject(postalCode!));
            Assert.Contains("PostalCode", ex.Message);
        }

        [Theory]
        [InlineData("1234")]       // too short
        [InlineData("123456789")]  // too long
        [InlineData("ABCDE-123")]  // invalid pattern
        public void Constructor_ShouldThrow_WhenPostalCodeInvalid(string invalidPostalCode)
        {
            var ex = Assert.Throws<ValueObjectException>(() => new PostalCodeValueObject(invalidPostalCode));
            Assert.Contains("PostalCode", ex.Message);
        }

        [Fact]
        public void Equals_ShouldReturnTrue_WhenPostalCodesAreSame()
        {
            var p1 = new PostalCodeValueObject("12345-678");
            var p2 = new PostalCodeValueObject("12345-678");

            Assert.Equal(p1, p2);
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenPostalCodesAreDifferent()
        {
            var p1 = new PostalCodeValueObject("12345-678");
            var p2 = new PostalCodeValueObject("87654-321");

            Assert.NotEqual(p1, p2);
        }
    }
}