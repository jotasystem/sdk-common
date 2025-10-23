using JotaSystem.Sdk.Common.ValueObjects;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;

namespace JotaSystem.Sdk.Common.Tests.ValueObjects
{
    public class NameValueObjectTest
    {
        [Fact]
        public void Constructor_ShouldAssignValues_WhenValid()
        {
            var vo = new NameValueObject(" João ", " Silva ");

            Assert.Equal("João", vo.FirstName);
            Assert.Equal("Silva", vo.LastName);
            Assert.Equal("João Silva", vo.ToString());
        }

        [Theory]
        [InlineData(null, "Silva", "FirstName")]
        [InlineData("", "Silva", "FirstName")]
        [InlineData("João", null, "LastName")]
        [InlineData("João", "", "LastName")]
        public void Constructor_ShouldThrow_WhenRequiredFieldsMissing(string? firstName, string? lastName, string expectedField)
        {
            var ex = Assert.Throws<ValueObjectException>(() => new NameValueObject(firstName!, lastName!));
            Assert.Contains(expectedField, ex.Message);
        }

        [Theory]
        [InlineData("J", "Silva", "FirstName")]
        [InlineData("João", "S", "LastName")]
        [InlineData("ThisNameIsWayTooLongToBeValidAccordingToTheMaxLength", "Silva", "FirstName")]
        public void Constructor_ShouldThrow_WhenNameLengthInvalid(string firstName, string lastName, string expectedField)
        {
            var ex = Assert.Throws<ValueObjectException>(() => new NameValueObject(firstName, lastName));
            Assert.Contains(expectedField, ex.Message);
        }

        [Fact]
        public void Equals_ShouldReturnTrue_WhenNamesAreSame()
        {
            var n1 = new NameValueObject("João", "Silva");
            var n2 = new NameValueObject("João", "Silva");

            Assert.Equal(n1, n2);
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenNamesAreDifferent()
        {
            var n1 = new NameValueObject("João", "Silva");
            var n2 = new NameValueObject("Maria", "Silva");

            Assert.NotEqual(n1, n2);
        }
    }
}