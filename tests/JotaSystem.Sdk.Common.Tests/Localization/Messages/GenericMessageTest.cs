using JotaSystem.Sdk.Common.Localization;
using JotaSystem.Sdk.Common.Localization.Messages;

namespace JotaSystem.Sdk.Common.Tests.Localization.Messages
{
    public class GenericMessageTest
    {
        [Theory]
        [InlineData(Language.PtBr, "Operação inválida: Teste.")]
        [InlineData(Language.EnUs, "Invalid operation: Teste.")]
        [InlineData(Language.EsEs, "Operación inválida: Teste.")]
        public void InvalidPattern_ShouldReturnLocalizedMessage(Language lang, string expected)
        {
            var message = GenericMessage.InvalidOperation("Teste", lang);
            Assert.Equal(expected, message);
        }
    }
}
