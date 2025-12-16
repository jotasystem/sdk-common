using JotaSystem.Sdk.Common.Extensions.String;

namespace JotaSystem.Sdk.Common.Tests.Extensions.String
{
    public class StringTransformExtensionTest
    {
        [Fact]
        public void ToTitleCase_ShouldConvertWordsToTitleCase()
        {
            Assert.Equal("Hello World", "hello world".ToTitleCase());
        }

        [Fact]
        public void ToSnakeCase_ShouldConvertToSnakeCase()
        {
            Assert.Equal("hello_world", "HelloWorld".ToSnakeCase());
            Assert.Equal("test_case_string", "Test Case String".ToSnakeCase());
        }

        [Fact]
        public void ToKebabCase_ShouldConvertCorrectly()
        {
            Assert.Equal("hello-world", "HelloWorld".ToKebabCase());
            Assert.Equal("test-case-string", "Test Case String".ToKebabCase());
        }

        [Fact]
        public void ToPascalCase_ShouldConvertCorrectly()
        {
            Assert.Equal("HelloWorld", "hello_world".ToPascalCase());
            Assert.Equal("MyTestString", "my_test-string".ToPascalCase());
        }

        [Fact]
        public void ToCamelCase_ShouldConvertToCamelCase()
        {
            Assert.Equal("helloWorld", "Hello world".ToCamelCase());
        }

        [Fact]
        public void RemoveAccents_ShouldRemoveDiacritics()
        {
            Assert.Equal("Ola Mundo", "Olá Mundo".RemoveAccents());
        }

        [Fact]
        public void ToSlug_ShouldGenerateSlug()
        {
            Assert.Equal("ola-mundo", "Olá Mundo!".ToSlug());
        }

        [Fact]
        public void CapitalizeFirstLetter_ShouldCapitalizeOnlyFirst()
        {
            Assert.Equal("Hello world", "hello world".CapitalizeFirstLetter());
        }

        [Fact]
        public void ReverseString_ShouldReverseCharacters()
        {
            Assert.Equal("odnuM aloH", "Hola Mundo".ReverseString());
        }

        [Fact]
        public void ToRgb_ShouldConvertHexToRgb()
        {
            // Arrange
            var hex = "#6750A4";

            // Act
            var result = hex.ToRgb();

            // Assert
            Assert.Equal("103, 80, 164", result);
        }

        [Fact]
        public void ToCssRgb_ShouldConvertHex()
        {
            Assert.Equal("240, 241, 247", "#F0F1F7".ToCssRgb());
        }

        [Fact]
        public void ToCssRgb_ShouldConvertRgb()
        {
            Assert.Equal("240, 241, 247", "rgb(240, 241, 247)".ToCssRgb());
        }

        [Fact]
        public void ToCssRgb_ShouldConvertRgba()
        {
            Assert.Equal("240, 241, 247", "rgba(240, 241, 247, 1)".ToCssRgb());
        }

        [Fact]
        public void ToCssRgb_ShouldReturnOriginal_WhenInvalid()
        {
            Assert.Equal("abc", "abc".ToCssRgb());
        }
    }
}