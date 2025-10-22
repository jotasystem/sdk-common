using JotaSystem.Sdk.Common.Helpers;

namespace JotaSystem.Sdk.Common.Tests.Helpers
{
    public class EmailHelperTest
    {
        [Theory]
        [InlineData("user@example.com", true)]
        [InlineData("USER@EXAMPLE.COM", true)]
        [InlineData("user.name@sub.domain.com", true)]
        [InlineData("invalid-email", false)]
        [InlineData("", false)]
        public void IsValidEmail_ShouldReturnExpected(string email, bool expected)
        {
            var result = EmailHelper.IsValidEmail(email);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetDomain_ShouldReturnDomain()
        {
            var email = "joao.silva@example.com";
            var domain = EmailHelper.GetDomain(email);
            Assert.Equal("example.com", domain);
        }

        [Theory]
        [InlineData("")]
        [InlineData("invalid-email")]
        public void GetDomain_ShouldThrow_WhenEmailInvalid(string email)
        {
            Assert.Throws<ArgumentException>(() => EmailHelper.GetDomain(email));
        }

        [Fact]
        public void MaskEmail_ShouldMaskCorrectly()
        {
            var email = "joao.silva@example.com";
            var masked = EmailHelper.MaskEmail(email);
            Assert.Equal("jo*****@example.com", masked);
        }

        [Theory]
        [InlineData("a@domain.com", "*a@domain.com")]
        [InlineData("ab@domain.com", "*b@domain.com")]
        public void MaskEmail_ShouldHandleShortLocalPart(string email, string expected)
        {
            var masked = EmailHelper.MaskEmail(email);
            Assert.Equal(expected, masked);
        }

        [Theory]
        [InlineData("")]
        [InlineData("invalid-email")]
        public void MaskEmail_ShouldThrow_WhenEmailInvalid(string email)
        {
            Assert.Throws<ArgumentException>(() => EmailHelper.MaskEmail(email));
        }
    }
}