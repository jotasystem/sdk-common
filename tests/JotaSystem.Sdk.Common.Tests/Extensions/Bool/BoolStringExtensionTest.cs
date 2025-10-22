using JotaSystem.Sdk.Common.Extensions.Bool;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Bool
{
    public class BoolStringExtensionTest
    {
        [Theory]
        [InlineData("true", true)]
        [InlineData("1", true)]
        [InlineData("yes", true)]
        [InlineData("y", true)]
        [InlineData("sim", true)]
        [InlineData("s", true)]
        [InlineData("false", false)]
        [InlineData("0", false)]
        [InlineData("no", false)]
        [InlineData("n", false)]
        [InlineData("nao", false)]
        [InlineData("não", false)]
        [InlineData("", false)]
        [InlineData("   ", false)]
        [InlineData("unknown", false)]
        public void ToBool_ShouldParseCorrectly(string input, bool expected) =>
            Assert.Equal(expected, input.ToBool());

        [Fact]
        public void EqualsBool_ShouldCompareCorrectly()
        {
            Assert.True("sim".EqualsBool("yes"));
            Assert.True("TRUE".EqualsBool("1"));
            Assert.False("sim".EqualsBool("não"));
        }
    }
}