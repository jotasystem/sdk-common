using JotaSystem.Sdk.Common.Extensions.String;

namespace JotaSystem.Sdk.Common.Tests.Extensions.String
{
    public class StringValidationExtensionTest
    {
        [Fact]
        public void IsEmail_ShouldValidateEmails()
        {
            Assert.True("user@test.com".IsEmail());
            Assert.False("invalid-email".IsEmail());
        }

        [Fact]
        public void IsUrl_ShouldValidateUrls()
        {
            Assert.True("https://www.google.com".IsUrl());
            Assert.False("not_a_url".IsUrl());
        }

        [Fact]
        public void IsAlpha_ShouldReturnTrueForOnlyLetters()
        {
            Assert.True("Teste".IsAlpha());
            Assert.False("Teste123".IsAlpha());
        }

        [Fact]
        public void IsAlphanumeric_ShouldReturnTrueForLettersAndNumbers()
        {
            Assert.True("Teste123".IsAlphanumeric());
            Assert.False("Teste!".IsAlphanumeric());
        }

        [Fact]
        public void IsInteger_ShouldDetectValidIntegers()
        {
            Assert.True("123".IsInteger());
            Assert.False("12.3".IsInteger());
        }

        [Fact]
        public void IsDecimal_ShouldDetectValidDecimals()
        {
            Assert.True("123.45".IsDecimal());
            Assert.False("abc".IsDecimal());
        }

        [Fact]
        public void IsGuid_ShouldDetectValidGuids()
        {
            Assert.True("d3e5b5f3-1c4e-4e3b-b4b1-bb0a523ac05d".IsGuid());
            Assert.False("not-a-guid".IsGuid());
        }

        [Fact]
        public void IsUpperCase_ShouldDetectUppercaseStrings()
        {
            Assert.True("HELLO".IsUpperCase());
            Assert.False("Hello".IsUpperCase());
        }

        [Fact]
        public void IsLowerCase_ShouldDetectLowercaseStrings()
        {
            Assert.True("hello".IsLowerCase());
            Assert.False("Hello".IsLowerCase());
        }

        [Fact]
        public void IsCpf_ShouldValidateCpf()
        {
            Assert.True("52998224725".IsCpf()); // válido
            Assert.False("12345678900".IsCpf()); // inválido
        }

        [Fact]
        public void IsCnpj_ShouldValidateCnpj()
        {
            Assert.True("11444777000161".IsCnpj()); // válido
            Assert.False("112223330001812".IsCnpj()); // inválido
        }
    }
}