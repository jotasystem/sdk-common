using JotaSystem.Sdk.Common.Localization;
using JotaSystem.Sdk.Common.Localization.Messages;

namespace JotaSystem.Sdk.Common.Tests.Localization.Messages
{
    public class NumericMessageTest
    {
        [Theory]
        [InlineData(Language.PtBr, "Valor deve ser positivo.")]
        [InlineData(Language.EnUs, "Valor must be positive.")]
        [InlineData(Language.EsEs, "Valor debe ser positivo.")]
        public void MustBePositive_ShouldReturnLocalizedMessage(Language lang, string expected)
        {
            var message = NumericMessage.MustBePositive("Valor", lang);
            Assert.Equal(expected, message);
        }

        [Theory]
        [InlineData(Language.PtBr, "Valor deve estar entre 1 e 10.")]
        [InlineData(Language.EnUs, "Valor must be between 1 and 10.")]
        [InlineData(Language.EsEs, "Valor debe estar entre 1 y 10.")]
        public void OutOfRange_ShouldReturnLocalizedMessage(Language lang, string expected)
        {
            var message = NumericMessage.OutOfRange("Valor", 1, 10, lang);
            Assert.Equal(expected, message);
        }

        [Theory]
        [InlineData(Language.PtBr, "Valor deve ser maior que 5.")]
        [InlineData(Language.EnUs, "Valor must be greater than 5.")]
        [InlineData(Language.EsEs, "Valor debe ser mayor que 5.")]
        public void MustBeGreaterThan_ShouldReturnLocalizedMessage(Language lang, string expected)
        {
            var message = NumericMessage.MustBeGreaterThan("Valor", 5, lang);
            Assert.Equal(expected, message);
        }

        [Theory]
        [InlineData(Language.PtBr, "Valor deve ser menor que 100.")]
        [InlineData(Language.EnUs, "Valor must be less than 100.")]
        [InlineData(Language.EsEs, "Valor debe ser menor que 100.")]
        public void MustBeLessThan_ShouldReturnLocalizedMessage(Language lang, string expected)
        {
            var message = NumericMessage.MustBeLessThan("Valor", 100, lang);
            Assert.Equal(expected, message);
        }

        [Fact]
        public void MustBePositive_ShouldUseDefaultLanguage_WhenNull()
        {
            LanguageProvider.SetDefault(Language.EsEs);
            var message = NumericMessage.MustBePositive("Monto");
            Assert.Equal("Monto debe ser positivo.", message);

            // Reset para não afetar outros testes
            LanguageProvider.SetDefault(Language.PtBr);
        }

        [Theory]
        [InlineData(Language.PtBr, "Saldo não é suficiente.")]
        [InlineData(Language.EnUs, "Balance is not enough.")]
        [InlineData(Language.EsEs, "Saldo no es suficiente.")]
        public void NotEnough_ShouldReturnLocalizedMessage(Language lang, string expected)
        {
            var fieldName = lang switch
            {
                Language.EnUs => "Balance",
                _ => "Saldo"
            };

            var message = NumericMessage.NotEnough(fieldName, lang);

            Assert.Equal(expected, message);
        }

    }
}