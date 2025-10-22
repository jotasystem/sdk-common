using System.Globalization;

namespace JotaSystem.Sdk.Common.Tests
{
    public class CultureFixture : IDisposable
    {
        private readonly CultureInfo _originalCulture;
        private readonly CultureInfo _originalUICulture;

        public CultureFixture()
        {
            _originalCulture = CultureInfo.CurrentCulture;
            _originalUICulture = CultureInfo.CurrentUICulture;

            // Define a cultura padrão desejada para todos os testes
            var culture = new CultureInfo("pt-BR");
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
        }

        public void Dispose()
        {
            // Restaura a cultura original após os testes
            CultureInfo.CurrentCulture = _originalCulture;
            CultureInfo.CurrentUICulture = _originalUICulture;
        }
    }
}