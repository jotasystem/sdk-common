using JotaSystem.Sdk.Common.Extensions.Number;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Number
{
    public class NumberFormattingExtensionTest
    {
        [Fact]
        public void ToCurrency_ShouldFormatCorrectly_InPtBr()
        {
            decimal value = 1234.56m;
            string result = value.ToCurrency("pt-BR");

            Assert.Contains("R$", result);
            Assert.Contains("1.234", result);
        }

        [Fact]
        public void ToCurrency_ShouldFormatCorrectly_InEnUs()
        {
            decimal value = 1234.56m;
            string result = value.ToCurrency("en-US");

            Assert.Contains("$", result);
            Assert.Contains("1,234", result);
        }

        [Fact]
        public void ToFormattedString_ShouldReturnTwoDecimalPlaces()
        {
            double value = 1234.5678;
            string result = value.ToFormattedString(2);
            Assert.Contains("1.234", result);
        }

        [Fact]
        public void ToOrdinal_ShouldReturnWithSuffix()
        {
            Assert.Equal("1º", 1.ToOrdinal());
            Assert.Equal("2º", 2.ToOrdinal());
        }

        [Fact]
        public void ToAbbreviated_ShouldReturnK_ForThousands()
        {
            Assert.Equal("1.2K", 1200d.ToAbbreviated());
        }

        [Fact]
        public void ToAbbreviated_ShouldReturnM_ForMillions()
        {
            Assert.Equal("1.0M", 1_000_000d.ToAbbreviated());
        }

        [Fact]
        public void ToAbbreviated_ShouldReturnB_ForBillions()
        {
            Assert.Equal("1.0B", 1_000_000_000d.ToAbbreviated());
        }

        [Fact]
        public void ToAbbreviated_ShouldReturnRawValue_WhenLessThanThousand()
        {
            Assert.Equal("999.0", 999d.ToAbbreviated());
        }
    }
}
