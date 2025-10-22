using JotaSystem.Sdk.Common.Extensions.Reflection;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Reflection
{
    [AttributeUsage(AttributeTargets.All)]
    public class SampleAttribute : Attribute { public string? Info { get; set; } }

    [Sample(Info = "Test")] public class TestClass { }

    public class ReflectionAttributeExtensionTest
    {
        [Fact]
        public void HasAttribute_ShouldReturnTrue_WhenAttributeExists()
        {
            var type = typeof(TestClass);
            Assert.True(type.HasAttribute<SampleAttribute>());
        }

        [Fact]
        public void GetAttribute_ShouldReturnAttributeInstance()
        {
            var type = typeof(TestClass);
            var attr = type.GetAttribute<SampleAttribute>();
            Assert.NotNull(attr);
            Assert.Equal("Test", attr!.Info);
        }
    }
}