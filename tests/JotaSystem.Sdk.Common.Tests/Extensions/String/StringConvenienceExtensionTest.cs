using JotaSystem.Sdk.Common.Extensions.String;

namespace JotaSystem.Sdk.Common.Tests.Extensions.String
{
    public class StringConvenienceExtensionTest
    {
        [Fact]
        public void DefaultIfNullOrEmpty_ShouldReturnDefaultForNullOrEmpty()
        {
            Assert.Equal("default", ((string)null!).DefaultIfNullOrEmpty("default"));
            Assert.Equal("default", "".DefaultIfNullOrEmpty("default"));
            Assert.Equal("value", "value".DefaultIfNullOrEmpty("default"));
        }

        [Fact]
        public void DefaultIfNullOrWhiteSpace_ShouldReturnDefaultForWhitespace()
        {
            Assert.Equal("default", ((string)null!).DefaultIfNullOrWhiteSpace("default"));
            Assert.Equal("default", "   ".DefaultIfNullOrWhiteSpace("default"));
            Assert.Equal("value", "value".DefaultIfNullOrWhiteSpace("default"));
        }

        [Fact]
        public void TruncateWithEllipsis_ShouldTruncateStringCorrectly()
        {
            Assert.Equal("Hello...", "Hello World".TruncateWithEllipsis(5));
            Assert.Equal("Hi", "Hi".TruncateWithEllipsis(5));
        }

        [Fact]
        public void Repeat_ShouldRepeatStringCorrectly()
        {
            Assert.Equal("aaa", "a".Repeat(3));
            Assert.Equal("", "a".Repeat(0));
        }

        [Fact]
        public void IfNullReturn_ShouldReturnFunctionResultForNull()
        {
            string value = null!;
            string result = value.IfNullReturn(() => "computed");
            Assert.Equal("computed", result);
        }

        [Fact]
        public void IfEmptyReturn_ShouldReturnFunctionResultForEmpty()
        {
            string value = "";
            string result = value.IfEmptyReturn(() => "computed");
            Assert.Equal("computed", result);
        }

        [Fact]
        public void ReplaceIfNullOrEmpty_ShouldReplaceWhenNullOrEmpty()
        {
            string value = null!;
            Assert.Equal("replacement", value.ReplaceIfNullOrEmpty("replacement"));
            value = "";
            Assert.Equal("replacement", value.ReplaceIfNullOrEmpty("replacement"));
            value = "existing";
            Assert.Equal("existing", value.ReplaceIfNullOrEmpty("replacement"));
        }

        [Fact]
        public void ToCharArraySafe_ShouldReturnEmptyArrayForNullOrEmpty()
        {
            Assert.Empty(((string)null!).ToCharArraySafe());
            Assert.Empty("".ToCharArraySafe());
            Assert.Equal(['a', 'b'], "ab".ToCharArraySafe());
        }
    }
}