using JotaSystem.Sdk.Common.Extensions.Enum;
using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Enum
{
    public class EnumConversionExtensionTest
    {
        private enum TestEnum
        {
            [Display(Name = "Teste 1")]
            Value1 = 1,
            Value2 = 2
        }

        [Fact]
        public void ToEnum_ShouldParseValidString()
        {
            Assert.Equal(TestEnum.Value1, "Value1".ToEnum<TestEnum>());
            Assert.Equal(TestEnum.Value2, "value2".ToEnum<TestEnum>()); // ignoreCase default true
        }

        [Fact]
        public void ToEnum_ShouldThrow_OnInvalidString()
        {
            Assert.Throws<ArgumentException>(() => "Invalid".ToEnum<TestEnum>());
        }

        [Fact]
        public void FromDisplayName_ShouldParseValidString()
        {
            Assert.Equal(TestEnum.Value1, "Teste 1".FromDisplayName<TestEnum>());
        }

        [Fact]
        public void ParseOrDefault_ShouldReturnEnum_WhenValid()
        {
            Assert.Equal(TestEnum.Value1, "Value1".ParseOrDefault(TestEnum.Value2));
        }

        [Fact]
        public void ParseOrDefault_ShouldReturnDefault_WhenInvalid()
        {
            Assert.Equal(TestEnum.Value2, "Invalid".ParseOrDefault(TestEnum.Value2));
        }

        [Fact]
        public void TryParseIgnoreCase_ShouldReturnTrue_WhenValid()
        {
            Assert.True("Value1".TryParseIgnoreCase(out TestEnum result));
            Assert.Equal(TestEnum.Value1, result);
        }

        [Fact]
        public void TryParseIgnoreCase_ShouldReturnFalse_WhenInvalid()
        {
            Assert.False("Invalid".TryParseIgnoreCase(out TestEnum result));
        }

        [Fact]
        public void GetValues_ShouldReturnAllEnumValues()
        {
            var values = EnumConversionExtension.GetValues<TestEnum>().ToList();
            Assert.Contains(TestEnum.Value1, values);
            Assert.Contains(TestEnum.Value2, values);
            Assert.Equal(2, values.Count);
        }

        [Fact]
        public void ToInt_ShouldReturnEnumIntegerValue()
        {
            Assert.Equal(1, TestEnum.Value1.ToInt());
            Assert.Equal(2, TestEnum.Value2.ToInt());
        }
    }
}
