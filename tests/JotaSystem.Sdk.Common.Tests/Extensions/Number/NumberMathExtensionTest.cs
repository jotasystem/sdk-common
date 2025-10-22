using JotaSystem.Sdk.Common.Extensions.Number;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Number
{
    public class NumberMathExtensionTest
    {
        [Fact]
        public void Clamp_ShouldReturnSameValue_WhenWithinRange()
        {
            Assert.Equal(5, 5.Clamp(1, 10));
        }

        [Fact]
        public void Clamp_ShouldReturnMin_WhenBelowRange()
        {
            Assert.Equal(1, 0.Clamp(1, 10));
        }

        [Fact]
        public void Clamp_ShouldReturnMax_WhenAboveRange()
        {
            Assert.Equal(10, 15.Clamp(1, 10));
        }

        [Fact]
        public void PercentOf_ShouldReturnCorrectValue()
        {
            Assert.Equal(50m, 25m.PercentOf(200m));
        }

        [Fact]
        public void AddPercent_ShouldIncreaseValueByPercentage()
        {
            Assert.Equal(110m, 100m.AddPercent(10m));
        }

        [Fact]
        public void SubtractPercent_ShouldDecreaseValueByPercentage()
        {
            Assert.Equal(90m, 100m.SubtractPercent(10m));
        }

        [Fact]
        public void RoundTo_ShouldRoundToTwoDecimals()
        {
            Assert.Equal(1.23m, 1.2345m.RoundTo(2));
        }

        [Fact]
        public void Abs_ShouldReturnPositiveValue()
        {
            Assert.Equal(5, (-5).Abs());
        }

        [Fact]
        public void MaxOf_ShouldReturnLargestValue()
        {
            Assert.Equal(10, 10.MaxOf(5));
        }

        [Fact]
        public void MinOf_ShouldReturnSmallestValue()
        {
            Assert.Equal(5, 10.MinOf(5));
        }
    }
}
