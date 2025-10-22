using JotaSystem.Sdk.Common.Extensions.Bool;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Bool
{
    public class BoolLogicExtensionTest
    {
        [Fact] public void And_ShouldReturnTrue_WhenBothTrue() => Assert.True(true.And(true));
        [Fact] public void And_ShouldReturnFalse_WhenAnyFalse() => Assert.False(true.And(false));

        [Fact] public void Or_ShouldReturnTrue_WhenAnyTrue() => Assert.True(true.Or(false));
        [Fact] public void Or_ShouldReturnFalse_WhenBothFalse() => Assert.False(false.Or(false));

        [Fact] public void Xor_ShouldReturnTrue_WhenOnlyOneTrue() => Assert.True(true.Xor(false));

        [Fact]
        public void Xor_ShouldReturnFalse_WhenBothTrueOrBothFalse()
        {
            Assert.False(true.Xor(true));
            Assert.False(false.Xor(false));
        }

        [Fact]
        public void Not_ShouldInvertValue()
        {
            Assert.False(true.Not());
            Assert.True(false.Not());
        }

        [Fact]
        public void Toggle_ShouldInvertValue()
        {
            Assert.True(true.Toggle().IsSameAs(false));
            Assert.True(false.Toggle().IsSameAs(true));
        }

        [Fact]
        public void IsSameAs_ShouldReturnTrue_WhenEqual()
        {
            Assert.True(true.IsSameAs(true));
            Assert.True(false.IsSameAs(false));
        }

        [Fact]
        public void IsSameAs_ShouldReturnFalse_WhenDifferent()
        {
            Assert.False(true.IsSameAs(false));
        }

        [Fact]
        public void IsOppositeOf_ShouldReturnTrue_WhenDifferent()
        {
            Assert.True(true.IsOppositeOf(false));
            Assert.True(false.IsOppositeOf(true));
        }

        [Fact]
        public void IsOppositeOf_ShouldReturnFalse_WhenEqual()
        {
            Assert.False(true.IsOppositeOf(true));
            Assert.False(false.IsOppositeOf(false));
        }
    }
}
