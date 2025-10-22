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
    }
}