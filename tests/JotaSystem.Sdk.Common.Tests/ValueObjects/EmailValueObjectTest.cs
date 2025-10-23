using JotaSystem.Sdk.Common.ValueObjects;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;

namespace JotaSystem.Sdk.Common.Tests.ValueObjects
{
    public class EmailValueObjectTest
    {
        [Fact]
        public void Constructor_ShouldAssignEmail_WhenValidEmailProvided()
        {
            // Arrange
            var email = "Example@Test.COM ";

            // Act
            var vo = new EmailValueObject(email);

            // Assert
            Assert.Equal("example@test.com", vo.Email);
            Assert.Equal("example@test.com", vo.ToString());
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Constructor_ShouldThrow_WhenEmailIsNullOrWhitespace(string? invalidEmail)
        {
            // Act & Assert
            var ex = Assert.Throws<ValueObjectException>(() => new EmailValueObject(invalidEmail!));
            Assert.Contains("Email", ex.Message);
        }

        [Theory]
        [InlineData("invalidemail")]
        [InlineData("test@")]
        [InlineData("@domain.com")]
        [InlineData("test@domain")]
        [InlineData("test@@domain.com")]
        public void Constructor_ShouldThrow_WhenEmailIsInvalidFormat(string invalidEmail)
        {
            // Act & Assert
            var ex = Assert.Throws<ValueObjectException>(() => new EmailValueObject(invalidEmail));
            Assert.Contains("Email", ex.Message);
        }

        [Fact]
        public void Equals_ShouldReturnTrue_WhenEmailsAreSame()
        {
            // Arrange
            var e1 = new EmailValueObject("user@test.com");
            var e2 = new EmailValueObject("USER@test.com");

            // Act & Assert
            Assert.Equal(e1, e2);
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenEmailsAreDifferent()
        {
            // Arrange
            var e1 = new EmailValueObject("user1@test.com");
            var e2 = new EmailValueObject("user2@test.com");

            // Act & Assert
            Assert.NotEqual(e1, e2);
        }
    }
}