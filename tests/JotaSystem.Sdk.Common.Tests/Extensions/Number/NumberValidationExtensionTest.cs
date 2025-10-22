using JotaSystem.Sdk.Common.Extensions.Number;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Number
{
    public class NumberValidationExtensionTest
    {
        [Fact]
        public void IsEven_ShouldReturnTrue_ForEvenNumbers()
        {
            Assert.True(4.IsEven());
            Assert.True(0.IsEven());
        }

        [Fact]
        public void IsEven_ShouldReturnFalse_ForOddNumbers()
        {
            Assert.False(3.IsEven());
        }

        [Fact]
        public void IsOdd_ShouldReturnTrue_ForOddNumbers()
        {
            Assert.True(3.IsOdd());
        }

        [Fact]
        public void IsOdd_ShouldReturnFalse_ForEvenNumbers()
        {
            Assert.False(2.IsOdd());
        }

        [Fact]
        public void IsPrime_ShouldReturnTrue_ForPrimeNumbers()
        {
            Assert.True(2.IsPrime());
            Assert.True(3.IsPrime());
            Assert.True(13.IsPrime());
        }

        [Fact]
        public void IsPrime_ShouldReturnFalse_ForNonPrimeNumbers()
        {
            Assert.False(1.IsPrime());
            Assert.False(4.IsPrime());
            Assert.False(9.IsPrime());
        }

        [Fact]
        public void IsBetween_ShouldReturnTrue_WhenValueInsideRange()
        {
            Assert.True(5.IsBetween(1, 10));
        }

        [Fact]
        public void IsBetween_ShouldReturnFalse_WhenValueOutsideRange()
        {
            Assert.False(11.IsBetween(1, 10));
        }

        [Fact]
        public void IsMultipleOf_ShouldReturnTrue_WhenIsMultiple()
        {
            Assert.True(10.IsMultipleOf(5));
        }

        [Fact]
        public void IsMultipleOf_ShouldReturnFalse_WhenNotMultiple()
        {
            Assert.False(10.IsMultipleOf(3));
        }
    }
}
