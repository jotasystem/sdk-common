using JotaSystem.Sdk.Common.Extensions.Dictionary;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Dictionary
{
    public class DictionarySafeExtensionTest
    {
        [Fact]
        public void GetValueOrDefault_ShouldReturnValueOrDefault()
        {
            var dict = new Dictionary<string, int> { ["a"] = 1 };
            Assert.Equal(1, dict.GetOrDefault("a"));
            Assert.Equal(0, dict.GetOrDefault("b"));
        }

        [Fact]
        public void AddOrUpdate_ShouldAddOrUpdateValue()
        {
            var dict = new Dictionary<string, int>();
            dict.AddOrUpdate("x", 5);
            Assert.Equal(5, dict["x"]);

            dict.AddOrUpdate("x", 10);
            Assert.Equal(10, dict["x"]);
        }

        [Fact]
        public void TryRemove_ShouldReturnTrue_WhenKeyExists()
        {
            var dict = new Dictionary<string, int> { ["k"] = 1 };
            Assert.True(dict.TryRemove("k"));
            Assert.False(dict.ContainsKey("k"));
        }
    }
}
