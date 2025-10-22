using JotaSystem.Sdk.Common.Extensions.Dictionary;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Dictionary
{
    public class DictionaryConversionExtensionTest
    {
        private class TestObj { public int X { get; set; } = 10; public string Y { get; set; } = "Test"; }

        [Fact]
        public void ToDictionary_ShouldReturnCorrectKeyValuePairs()
        {
            var obj = new TestObj();
            var dict = obj.ToDictionary();
            Assert.Equal(10, dict["X"]);
            Assert.Equal("Test", dict["Y"]);
        }

        [Fact]
        public void PopulateFromDictionary_ShouldSetPropertiesCorrectly()
        {
            var obj = new TestObj();
            var dict = new Dictionary<string, object?> { ["X"] = 20, ["Y"] = "Updated" };

            obj.PopulateFromDictionary(dict);
            Assert.Equal(20, obj.X);
            Assert.Equal("Updated", obj.Y);
        }
    }
}