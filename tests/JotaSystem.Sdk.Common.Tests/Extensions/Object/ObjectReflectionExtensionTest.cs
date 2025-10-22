using JotaSystem.Sdk.Common.Extensions.Object;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Object
{
    public class ObjectReflectionExtensionTest
    {
        private class Sample { public string Name { get; set; } = "Jota"; }

        [Fact]
        public void GetPropertyValue_ShouldReturnCorrectValue()
        {
            var obj = new Sample();
            Assert.Equal("Jota", obj.GetPropertyValue("Name"));
        }

        [Fact]
        public void HasProperty_ShouldReturnTrueForExistingProperty()
        {
            var obj = new Sample();
            Assert.True(obj.HasProperty("Name"));
        }

        [Fact]
        public void GetPropertiesDictionary_ShouldContainProperty()
        {
            var obj = new Sample();
            var dict = obj.GetPropertiesDictionary();
            Assert.Contains("Name", dict.Keys);
        }
    }
}
