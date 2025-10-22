using JotaSystem.Sdk.Common.Localization;

namespace JotaSystem.Sdk.Common.Tests.Localization
{
    public class LanguageProviderTest
    {
        [Fact]
        public void DefaultLanguage_ShouldBe_PtBr()
        {
            Assert.Equal(Language.PtBr, LanguageProvider.DefaultLanguage);
        }

        [Fact]
        public void SetDefault_ShouldChangeDefaultLanguage()
        {
            // Arrange
            LanguageProvider.SetDefault(Language.EnUs);

            // Act
            var result = LanguageProvider.DefaultLanguage;

            // Assert
            Assert.Equal(Language.EnUs, result);

            // Reset
            LanguageProvider.SetDefault(Language.PtBr);
        }

        [Fact]
        public void Use_ShouldReturnProvidedLanguage()
        {
            var result = LanguageProvider.Use(Language.EsEs);
            Assert.Equal(Language.EsEs, result);
        }

        [Fact]
        public void Use_ShouldReturnDefault_WhenNull()
        {
            LanguageProvider.SetDefault(Language.EnUs);
            var result = LanguageProvider.Use(null);
            Assert.Equal(Language.EnUs, result);

            // Reset
            LanguageProvider.SetDefault(Language.PtBr);
        }

        [Theory]
        [InlineData(Language.PtBr, "pt-BR")]
        [InlineData(Language.EnUs, "en-US")]
        [InlineData(Language.EsEs, "es-ES")]
        public void GetCode_ShouldReturnExpected(Language lang, string expected)
        {
            var result = LanguageProvider.GetCode(lang);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetCode_ShouldUseDefault_WhenNull()
        {
            LanguageProvider.SetDefault(Language.EsEs);
            var result = LanguageProvider.GetCode();
            Assert.Equal("es-ES", result);

            // Reset
            LanguageProvider.SetDefault(Language.PtBr);
        }
    }
}