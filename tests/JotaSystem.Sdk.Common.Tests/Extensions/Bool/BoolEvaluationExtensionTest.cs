using JotaSystem.Sdk.Common.Extensions.Bool;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Bool
{
    public class BoolEvaluationExtensionTest
    {
        [Fact]
        public void IfTrue_ShouldExecuteAction_WhenTrue()
        {
            bool called = false;
            true.IfTrue(() => called = true);
            Assert.True(called);
        }

        [Fact]
        public void IfTrue_ShouldNotExecuteAction_WhenFalse()
        {
            bool called = false;
            false.IfTrue(() => called = true);
            Assert.False(called);
        }

        [Fact]
        public void IfFalse_ShouldExecuteAction_WhenFalse()
        {
            bool called = false;
            false.IfFalse(() => called = true);
            Assert.True(called);
        }

        [Fact]
        public void IfFalse_ShouldNotExecuteAction_WhenTrue()
        {
            bool called = false;
            true.IfFalse(() => called = true);
            Assert.False(called);
        }

        [Fact]
        public void IfTrue_ShouldReturnCorrectValue()
        {
            Assert.Equal("ok", true.IfTrue("ok", "fail"));
            Assert.Equal("fail", false.IfTrue("ok", "fail"));
        }

        [Fact]
        public void OrIfFalse_ShouldReturnAlternate()
        {
            Assert.True(false.OrIfFalse(true));
            Assert.True(true.OrIfFalse(false));
        }

        [Fact]
        public void OrIfTrue_ShouldReturnAlternate()
        {
            Assert.False(true.OrIfTrue(false));
            Assert.False(false.OrIfTrue(true));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        public void IsTruthy_ShouldReturnExpected_ForBool(bool input, bool expected)
        {
            Assert.Equal(expected, input.IsTruthy());
        }

        [Theory]
        [InlineData("yes", true)]
        [InlineData("0", false)]
        [InlineData(1, true)]
        [InlineData(0, false)]
        [InlineData(123, true)]
        [InlineData("", false)]
        public void IsTruthy_ShouldHandleVariousTypes(object value, bool expected)
        {
            Assert.Equal(expected, value.IsTruthy());
        }
    }
}