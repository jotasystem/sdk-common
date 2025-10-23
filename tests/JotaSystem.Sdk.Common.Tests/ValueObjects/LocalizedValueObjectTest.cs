using System.Globalization;
using JotaSystem.Sdk.Common.ValueObjects;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;

namespace JotaSystem.Sdk.Common.Tests.ValueObjects
{
    public class LocalizedValueObjectTest
    {
        [Fact]
        public void Constructor_ShouldAssignValues_WhenValid()
        {
            var vo = new LocalizedValueObject("Olá", "Hello", "Hola");

            Assert.Equal("Olá", vo.Portuguese);
            Assert.Equal("Hello", vo.English);
            Assert.Equal("Hola", vo.Spanish);
        }

        [Theory]
        [InlineData(null, "Hello", "Hola", "Portuguese")]
        [InlineData("Olá", null, "Hola", "English")]
        [InlineData("Olá", "Hello", null, "Spanish")]
        public void Constructor_ShouldThrow_WhenRequiredFieldsMissing(string? pt, string? en, string? es, string expectedField)
        {
            var ex = Assert.Throws<ValueObjectException>(() => new LocalizedValueObject(pt!, en!, es!));
            Assert.Contains(expectedField, ex.Message);
        }

        [Fact]
        public void ToString_ShouldReturnPortuguese_WhenCultureIsPtBr()
        {
            CultureInfo.CurrentUICulture = new CultureInfo("pt-BR");
            var vo = new LocalizedValueObject("Olá", "Hello", "Hola");

            Assert.Equal("Olá", vo.ToString());
        }

        [Fact]
        public void ToString_ShouldReturnEnglish_WhenCultureIsEnUs()
        {
            CultureInfo.CurrentUICulture = new CultureInfo("en-US");
            var vo = new LocalizedValueObject("Olá", "Hello", "Hola");

            Assert.Equal("Hello", vo.ToString());
        }

        [Fact]
        public void ToString_ShouldReturnSpanish_WhenCultureIsEsEs()
        {
            CultureInfo.CurrentUICulture = new CultureInfo("es-ES");
            var vo = new LocalizedValueObject("Olá", "Hello", "Hola");

            Assert.Equal("Hola", vo.ToString());
        }

        [Fact]
        public void ToString_ShouldFallbackToPortuguese_WhenUnsupportedCulture()
        {
            CultureInfo.CurrentUICulture = new CultureInfo("fr-FR");
            var vo = new LocalizedValueObject("Olá", "Hello", "Hola");

            Assert.Equal("Olá", vo.ToString());
        }

        [Fact]
        public void Equals_ShouldReturnTrue_ForSameValues()
        {
            var a = new LocalizedValueObject("Olá", "Hello", "Hola");
            var b = new LocalizedValueObject("Olá", "Hello", "Hola");

            Assert.True(a.Equals(b));
        }

        [Fact]
        public void Equals_ShouldReturnFalse_ForDifferentValues()
        {
            var a = new LocalizedValueObject("Oi", "Hello", "Hola");
            var b = new LocalizedValueObject("Olá", "Hello", "Hola");

            Assert.False(a.Equals(b));
        }
    }
}