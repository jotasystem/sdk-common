using JotaSystem.Sdk.Common.Helpers;

namespace JotaSystem.Sdk.Common.Tests.Helpers
{
    public class GeneratorHelperTest
    {
        [Fact]
        public void Generate_ShouldCreateCode_WithPrefixAndLength()
        {
            var result = GeneratorHelper.Code("VND", 7);

            Assert.StartsWith("VND-", result);
            Assert.Equal(11, result.Length); // VND- + 7 chars
        }

        [Fact]
        public void Generate_ShouldCreateOnlyLetters_WhenConfigured()
        {
            var result = GeneratorHelper.Code("PDT", 4, useNumbers: false);

            var codePart = result.Split('-')[1];

            Assert.All(codePart, c => Assert.True(char.IsLetter(c)));
        }

        [Fact]
        public void Generate_ShouldCreateOnlyNumbers_WhenConfigured()
        {
            var result = GeneratorHelper.Code("PED", 6, useLetters: false);

            var codePart = result.Split('-')[1];

            Assert.All(codePart, c => Assert.True(char.IsDigit(c)));
        }

        [Fact]
        public void GenerateLetters_ShouldCreateOnlyLetters()
        {
            var result = GeneratorHelper.CodeLetters("PDT", 4);

            var codePart = result.Split('-')[1];

            Assert.All(codePart, c => Assert.True(char.IsLetter(c)));
        }

        [Fact]
        public void GenerateNumbers_ShouldCreateOnlyNumbers()
        {
            var result = GeneratorHelper.CodeNumbers("PED", 6);

            var codePart = result.Split('-')[1];

            Assert.All(codePart, c => Assert.True(char.IsDigit(c)));
        }

        [Fact]
        public void Generate_ShouldThrow_WhenPrefixIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
                GeneratorHelper.Code("", 5));
        }

        [Fact]
        public void Generate_ShouldThrow_WhenLengthIsInvalid()
        {
            Assert.Throws<ArgumentException>(() =>
                GeneratorHelper.Code("VND", 0));
        }

        [Fact]
        public void Generate_ShouldThrow_WhenNoCharactersAvailable()
        {
            Assert.Throws<InvalidOperationException>(() =>
                GeneratorHelper.Code("VND", 5, useLetters: false, useNumbers: false));
        }
    }
}