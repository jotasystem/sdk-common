using JotaSystem.Sdk.Common.Helpers;
using JotaSystem.Sdk.Common.ValueObjects;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;
using Xunit;

namespace JotaSystem.Sdk.Common.Tests.ValueObjects
{
    public class PasswordValueObjectTest
    {
        [Theory]
        [InlineData("Abc123!@#")]
        [InlineData("StrongP@ssword1")]
        public void Constructor_ShouldAssignPassword_WhenValid(string validPassword)
        {
            var vo = new PasswordValueObject(validPassword);

            Assert.Equal(validPassword, vo.Password);
            Assert.Equal(validPassword, vo.ToString());
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Constructor_ShouldThrow_WhenPasswordIsNullOrWhitespace(string? invalidPassword)
        {
            var ex = Assert.Throws<ValueObjectException>(() => new PasswordValueObject(invalidPassword!));
            Assert.Contains("Password", ex.Message);
        }

        [Theory]
        [InlineData("123")] // too short
        [InlineData("a")]   // too short
        [InlineData("Abc")] // too short
        public void Constructor_ShouldThrow_WhenPasswordTooShort(string shortPassword)
        {
            var ex = Assert.Throws<ValueObjectException>(() => new PasswordValueObject(shortPassword));
            Assert.Contains("Password", ex.Message);
        }

        [Fact]
        public void Constructor_ShouldThrow_WhenPasswordNotStrong()
        {
            // Arrange
            string weakPassword = "password123"; // não atende critérios do PasswordHelper

            // Act & Assert
            var ex = Assert.Throws<ValueObjectException>(() => new PasswordValueObject(weakPassword));
            Assert.Contains("Password", ex.Message);
        }

        [Fact]
        public void Equals_ShouldReturnTrue_WhenPasswordsAreSame()
        {
            var p1 = new PasswordValueObject("Abc123!@#");
            var p2 = new PasswordValueObject("Abc123!@#");

            Assert.Equal(p1, p2);
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenPasswordsAreDifferent()
        {
            var p1 = new PasswordValueObject("Abc123!@#");
            var p2 = new PasswordValueObject("Xyz789!@#");

            Assert.NotEqual(p1, p2);
        }
    }
}