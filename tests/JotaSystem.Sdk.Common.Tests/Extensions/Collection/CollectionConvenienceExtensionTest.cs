using JotaSystem.Sdk.Common.Extensions.Collection;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Collection
{
    public class CollectionConvenienceExtensionTest
    {
        [Fact]
        public void IsNullOrEmpty_ShouldReturnTrueForNullOrEmpty()
        {
            List<int>? nullList = null;
            var emptyList = new List<int>();

            Assert.True(nullList.IsNullOrEmpty());
            Assert.True(emptyList.IsNullOrEmpty());

            var nonEmpty = new List<int> { 1 };
            Assert.False(nonEmpty.IsNullOrEmpty());
        }

        [Fact]
        public void HasItems_ShouldReturnOppositeOfIsNullOrEmpty()
        {
            List<int>? nullList = null;
            var emptyList = new List<int>();
            var nonEmpty = new List<int> { 1 };

            Assert.False(nullList.HasItems());
            Assert.False(emptyList.HasItems());
            Assert.True(nonEmpty.HasItems());
        }
    }
}