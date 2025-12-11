using JotaSystem.Sdk.Common.Extensions.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Enum
{
    public class EnumDescriptionExtensionTest
    {
        private enum TestEnum
        {
            [Display(Name = "Nome Exibido")]
            Value,
            [Description("Descrição 1")]
            Value1,
            Value2
        }

        [Fact]
        public void GetDisplayName_ShouldReturnDisplayName_WhenPresent()
        {
            Assert.Equal("Nome Exibido", TestEnum.Value.GetDisplayName());
        }

        [Fact]
        public void GetDisplayName_ShouldReturnDescription_WhenDisplayNotPresent_ButDescriptionExists()
        {
            Assert.Equal("Descrição 1", TestEnum.Value1.GetDisplayName());
        }

        [Fact]
        public void GetDisplayName_ShouldReturnEnumName_WhenNoAttribute()
        {
            Assert.Equal("Value2", TestEnum.Value2.GetDisplayName());
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