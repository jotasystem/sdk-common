using JotaSystem.Sdk.Common.Localization;
using JotaSystem.Sdk.Common.Localization.Messages;

namespace JotaSystem.Sdk.Common.Tests.Localization.Messages
{
    public class DateMessageTest : IClassFixture<CultureFixture>
    {
        private readonly DateTime _min = new(2024, 1, 1);
        private readonly DateTime _max = new(2024, 12, 31);

        [Theory]
        [InlineData(Language.PtBr, "Data deve ser uma data futura.")]
        [InlineData(Language.EnUs, "Data must be a future date.")]
        [InlineData(Language.EsEs, "Data debe ser una fecha futura.")]
        public void MustBeFuture_ShouldReturnLocalizedMessage(Language lang, string expected)
        {
            var message = DateMessage.MustBeFuture("Data", lang);
            Assert.Equal(expected, message);
        }

        [Theory]
        [InlineData(Language.PtBr, "Data deve ser uma data passada.")]
        [InlineData(Language.EnUs, "Data must be a past date.")]
        [InlineData(Language.EsEs, "Data debe ser una fecha pasada.")]
        public void MustBePast_ShouldReturnLocalizedMessage(Language lang, string expected)
        {
            var message = DateMessage.MustBePast("Data", lang);
            Assert.Equal(expected, message);
        }

        [Theory]
        [InlineData(Language.PtBr, "Data deve estar entre")]
        [InlineData(Language.EnUs, "Data must be between")]
        [InlineData(Language.EsEs, "Data debe estar entre")]
        public void OutOfRange_ShouldReturnLocalizedMessage(Language lang, string expected)
        {
            var message = DateMessage.OutOfRange("Data", _min, _max, lang);
            Assert.Contains(expected, message);
        }

        [Fact]
        public void MustBeFuture_ShouldUseDefaultLanguage_WhenNull()
        {
            LanguageProvider.SetDefault(Language.EnUs);
            var message = DateMessage.MustBeFuture("Date");
            Assert.Equal("Date must be a future date.", message);

            // Reset
            LanguageProvider.SetDefault(Language.PtBr);
        }
    }
}