using JotaSystem.Sdk.Common.Extensions.Reflection;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Reflection
{
    public class ReflectionPropertyExtensionTest
    {
        private class TestObj { public int Number { get; set; } = 42; public string? Name { get; set; } = "Jota"; }

        [Fact]
        public void GetPropertyValue_ShouldReturnCorrectValue()
        {
            var obj = new TestObj();
            Assert.Equal(42, obj.GetPropertyValue("Number"));
            Assert.Equal("Jota", obj.GetPropertyValue("Name"));
        }

        [Fact]
        public void SetPropertyValue_ShouldUpdateValue()
        {
            var obj = new TestObj();
            obj.SetPropertyValue("Number", 99);
            obj.SetPropertyValue("Name", "Test");
            Assert.Equal(99, obj.Number);
            Assert.Equal("Test", obj.Name);
        }

        [Fact]
        public void TryGetPropertyValue_ShouldReturnDefault_WhenTypeMismatch()
        {
            var obj = new TestObj();
            Assert.Null(obj.TryGetPropertyValue<int?>("Name"));
        }
    }
}