using JotaSystem.Sdk.Common.Extensions.Dictionary;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Dictionary
{
    public class DictionaryMergeExtensionTest
    {
        [Fact]
        public void MergeWith_ShouldCombineAndOverwrite()
        {
            var dict1 = new Dictionary<string, int> { ["a"] = 1, ["b"] = 2 };
            var dict2 = new Dictionary<string, int> { ["b"] = 20, ["c"] = 3 };

            dict1.MergeWith(dict2);
            Assert.Equal(1, dict1["a"]);
            Assert.Equal(20, dict1["b"]);
            Assert.Equal(3, dict1["c"]);
        }
    }
}