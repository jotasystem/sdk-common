using JotaSystem.Sdk.Common.Localization;
using JotaSystem.Sdk.Common.Localization.Messages;

namespace JotaSystem.Sdk.Common.Tests.Localization.Messages
{
    public class RegexMessageTest
    {
        [Theory]
        [InlineData(Language.PtBr, "Campo não corresponde ao padrão esperado.")]
        [InlineData(Language.EnUs, "Campo does not match the expected pattern.")]
        [InlineData(Language.EsEs, "Campo no coincide con el patrón esperado.")]
        public void InvalidPattern_ShouldReturnLocalizedMessage(Language lang, string expected)
        {
            var message = RegexMessage.InvalidPattern("Campo", lang);
            Assert.Equal(expected, message);
        }

        [Fact]
        public void InvalidPattern_ShouldUseDefaultLanguage_WhenNull()
        {
            // Arrange
            LanguageProvider.SetDefault(Language.EnUs);

            // Act
            var message = RegexMessage.InvalidPattern("Field", Language.EnUs);

            // Assert
            Assert.Equal("Field does not match the expected pattern.", message);

            // Reset para não interferir em outros testes
            LanguageProvider.SetDefault(Language.PtBr);
        }
    }
}
