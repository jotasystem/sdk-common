using JotaSystem.Sdk.Common.Extensions.String;

namespace JotaSystem.Sdk.Common.Tests.Extensions.String
{
    public class StringManipulationExtensionTest
    {
        [Fact]
        public void Between_ShouldReturnSubstringBetweenDelimiters()
        {
            string value = "Hello [World]!";
            string result = value.Between("[", "]");
            Assert.Equal("World", result);
        }

        [Fact]
        public void Left_ShouldReturnCorrectSubstring()
        {
            Assert.Equal("Hel", "Hello".Left(3));
        }

        [Fact]
        public void Right_ShouldReturnCorrectSubstring()
        {
            Assert.Equal("rld", "World".Right(3));
        }

        [Fact]
        public void RemoveNumbers_ShouldRemoveAllDigits()
        {
            Assert.Equal("abc", "a1b2c3".RemoveNumbers());
        }

        [Fact]
        public void RemoveLetters_ShouldRemoveAllLetters()
        {
            Assert.Equal("123!", "abc123!".RemoveLetters());
        }

        [Fact]
        public void OnlyNumbers_ShouldReturnDigitsOnly()
        {
            Assert.Equal("123", "a1b2c3".OnlyNumbers());
        }

        [Fact]
        public void OnlyLetters_ShouldReturnLettersOnly()
        {
            Assert.Equal("abc", "a1b2c3".OnlyLetters());
        }

        [Fact]
        public void EnsureEndsWith_ShouldAppendSuffixIfMissing()
        {
            Assert.Equal("Test.txt", "Test".EnsureEndsWith(".txt"));
        }

        [Fact]
        public void EnsureStartsWith_ShouldAppendPrefixIfMissing()
        {
            Assert.Equal("PRE-Test", "Test".EnsureStartsWith("PRE-"));
        }

        [Fact]
        public void LimitWords_ShouldReturnLimitedWords()
        {
            string value = "one two three four";
            Assert.Equal("one two", value.LimitWords(2));
        }

        [Fact]
        public void PadLeftCustom_ShouldPadStringCorrectly()
        {
            string result = "7".PadLeftCustom(3, '0');
            Assert.Equal("007", result);
        }
    }
}