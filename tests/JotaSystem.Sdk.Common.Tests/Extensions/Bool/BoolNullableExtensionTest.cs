using JotaSystem.Sdk.Common.Extensions.Bool;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Bool
{
    public class BoolNullableExtensionTest
    {
        [Fact]
        public void GetValueOrDefault_ShouldReturnDefault_WhenNull() =>
            Assert.False(((bool?)null).GetValueOrDefault());

        [Fact]
        public void GetValueOrDefault_ShouldReturnValue_WhenNotNull() =>
            Assert.True(((bool?)true).GetValueOrDefault(false));

        [Fact]
        public void IsTrue_ShouldReturnTrue_WhenValueTrue() =>
            Assert.True(((bool?)true).IsTrue());

        [Fact]
        public void IsTrue_ShouldReturnFalse_WhenValueFalseOrNull()
        {
            Assert.False(((bool?)false).IsTrue());
            Assert.False(((bool?)null).IsTrue());
        }

        [Fact]
        public void IsFalse_ShouldReturnTrue_WhenValueFalse() =>
            Assert.True(((bool?)false).IsFalse());

        [Fact]
        public void IsFalse_ShouldReturnFalse_WhenValueTrueOrNull()
        {
            Assert.False(((bool?)true).IsFalse());
            Assert.False(((bool?)null).IsFalse());
        }
    }
}