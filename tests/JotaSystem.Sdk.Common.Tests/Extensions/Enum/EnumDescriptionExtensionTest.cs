using JotaSystem.Sdk.Common.Extensions.Enum;
using System.ComponentModel;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Enum
{
    public class EnumDescriptionExtensionTest
    {
        private enum TestEnum
        {
            [Description("Descrição 1")]
            Value1,
            Value2
        }

        [Fact]
        public void GetDescription_ShouldReturnAttributeDescription_WhenPresent()
        {
            Assert.Equal("Descrição 1", TestEnum.Value1.GetDescription());
        }

        [Fact]
        public void GetDescription_ShouldReturnName_WhenNoAttribute()
        {
            Assert.Equal("Value2", TestEnum.Value2.GetDescription());
        }

        [Fact]
        public void GetName_ShouldReturnEnumName()
        {
            Assert.Equal("Value1", TestEnum.Value1.GetName());
            Assert.Equal("Value2", TestEnum.Value2.GetName());
        }
    }
}