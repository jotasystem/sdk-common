using JotaSystem.Sdk.Common.Extensions.String;

namespace JotaSystem.Sdk.Common.Tests.Extensions.String
{
    public class StringCleaningExtensionTest
    {
        [Fact]
        public void RemoveHtmlTags_ShouldRemoveTags()
        {
            var input = "<p>Hello <strong>World</strong></p>";
            var result = input.RemoveHtmlTags();
            Assert.Equal("Hello World", result);
        }

        [Fact]
        public void RemoveNonPrintableChars_ShouldRemoveControlChars()
        {
            var input = "Hello\u0009World\u000A";
            var result = input.RemoveNonPrintableChars();
            Assert.Equal("HelloWorld", result);
        }

        [Fact]
        public void NormalizeWhitespace_ShouldReplaceMultipleSpacesWithSingle()
        {
            var input = "Hello     World   Test";
            var result = input.NormalizeWhitespace();
            Assert.Equal("Hello World Test", result);
        }

        [Fact]
        public void RemoveSpecialCharacters_ShouldKeepOnlyLettersNumbersAndSpaces()
        {
            var input = "Hello@World#123!";
            var result = input.RemoveSpecialCharacters();
            Assert.Equal("HelloWorld123", result);
        }

        [Fact]
        public void RemoveLineBreaks_ShouldRemoveAllBreaks()
        {
            var input = "Line1\r\nLine2\nLine3";
            var result = input.RemoveLineBreaks();
            Assert.Equal("Line1Line2Line3", result);
        }

        [Fact]
        public void CleanSpaces_ShouldTrimAndNormalizeInternalSpaces()
        {
            var input = "  Hello    World  ";
            var result = input.CleanSpaces();
            Assert.Equal("Hello World", result);
        }

        [Fact]
        public void RemoveTabs_ShouldRemoveAllTabs()
        {
            var input = "Hello\tWorld";
            var result = input.RemoveTabs();
            Assert.Equal("HelloWorld", result);
        }

        [Fact]
        public void RemovePunctuation_ShouldRemoveCommonPunctuationMarks()
        {
            var input = "Olá, mundo! Tudo bem?";
            var result = input.RemovePunctuation();
            Assert.Equal("Olá mundo Tudo bem", result);
        }
    }
}