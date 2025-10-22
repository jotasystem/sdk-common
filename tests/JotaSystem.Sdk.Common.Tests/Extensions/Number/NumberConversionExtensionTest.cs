using JotaSystem.Sdk.Common.Extensions.Number;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Number
{
    public class NumberConversionExtensionTest
    {
        [Fact]
        public void ToIntSafe_ShouldConvertValidString()
        {
            Assert.Equal(123, "123".ToIntSafe());
        }

        [Fact]
        public void ToIntSafe_ShouldReturnDefault_ForInvalidString()
        {
            Assert.Equal(0, "abc".ToIntSafe());
        }

        [Fact]
        public void ToDecimalSafe_ShouldConvertValidString()
        {
            Assert.Equal(12.34m, "12.34".ToDecimalSafe());
        }

        [Fact]
        public void ToDecimalSafe_ShouldReturnDefault_ForInvalidString()
        {
            Assert.Equal(0m, "abc".ToDecimalSafe());
        }

        [Fact]
        public void ToDouble_ShouldConvertDecimalToDouble()
        {
            Assert.Equal(12.34, 12.34m.ToDouble(), 2);
        }

        [Fact]
        public void ToDecimal_ShouldConvertDoubleToDecimal()
        {
            Assert.Equal(12.34m, 12.34.ToDecimal());
        }
    }
}
