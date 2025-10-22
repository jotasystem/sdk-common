using JotaSystem.Sdk.Common.Helpers;

namespace JotaSystem.Sdk.Common.Tests.Helpers
{
    public class PasswordHelperTests
    {
        // IsSequential
        [Theory]
        [InlineData("123456", true)]
        [InlineData("abcdef", true)]
        [InlineData("password", true)]
        [InlineData("654321", true)]
        [InlineData("098765", true)]
        [InlineData("qwerty", true)]
        [InlineData("P@ssw0rd", false)]
        [InlineData("Strong1!", false)]
        public void IsSequential_ShouldDetectSequentialPasswords(string password, bool expected)
        {
            var result = PasswordHelper.IsSequential(password);
            Assert.Equal(expected, result);
        }

        // IsCommonPassword
        [Theory]
        [InlineData("12345678", true)]
        [InlineData("password", true)]
        [InlineData("letmein", true)]
        [InlineData("admin", true)]
        [InlineData("Strong1!", false)]
        [InlineData("MySecurePass123!", false)]
        public void IsCommonPassword_ShouldDetectCommonPasswords(string password, bool expected)
        {
            var result = PasswordHelper.IsCommonPassword(password);
            Assert.Equal(expected, result);
        }

        // IsStrong
        [Theory]
        [InlineData("Strong1!", true)]      // forte
        [InlineData("WeakPass", false)]     // sem número e caractere especial
        [InlineData("12345678", false)]     // comum
        [InlineData("abcdef", false)]       // sequencial
        [InlineData("", false)]             // vazio
        [InlineData(null, false)]           // nulo
        [InlineData("Aa1!", false)]         // menos de 8 caracteres
        [InlineData("NoNumber!", false)]    // sem número
        [InlineData("nonumbers1", false)]   // sem maiúscula e sem caractere especial
        public void IsStrong_ShouldValidatePasswordStrength(string password, bool expected)
        {
            var result = PasswordHelper.IsStrong(password);
            Assert.Equal(expected, result);
        }
    }
}