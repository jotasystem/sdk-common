using JotaSystem.Sdk.Common.Extensions.String;

namespace JotaSystem.Sdk.Common.Tests.Extensions.String
{
    public class StringSearchExtensionTest
    {
        [Fact]
        public void ReplaceFirst_ShouldReplaceOnlyFirstOccurrence()
        {
            string value = "one two one two";
            string result = value.ReplaceFirst("one", "1");
            Assert.Equal("1 two one two", result);
        }

        [Fact]
        public void ReplaceLast_ShouldReplaceOnlyLastOccurrence()
        {
            string value = "one two one two";
            string result = value.ReplaceLast("one", "1");
            Assert.Equal("one two 1 two", result);
        }

        [Fact]
        public void RemoveAll_ShouldRemoveMultipleValues()
        {
            string value = "hello world example";
            string result = value.RemoveAll("world", "example");
            Assert.Equal("hello  ", result);
        }

        [Fact]
        public void IndexOfNth_ShouldReturnCorrectPosition()
        {
            string value = "test-test-test";
            int index = value.IndexOfNth("test", 2);
            Assert.Equal(5, index);
        }

        [Fact]
        public void StartsWithIgnoreCase_ShouldBeCaseInsensitive()
        {
            Assert.True("Hello".StartsWithIgnoreCase("he"));
        }

        [Fact]
        public void EndsWithIgnoreCase_ShouldBeCaseInsensitive()
        {
            Assert.True("HelloWorld".EndsWithIgnoreCase("WORLD"));
        }

        [Fact]
        public void IndexOfNth_ShouldReturnMinusOne_WhenOccurrenceNotFound()
        {
            string value = "abc";
            int index = value.IndexOfNth("x", 1);
            Assert.Equal(-1, index);
        }
    }
}