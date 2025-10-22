using JotaSystem.Sdk.Common.Extensions.Collection;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Collection
{
    public class CollectionOrderExtensionTest
    {
        [Fact]
        public void OrderBySafe_ShouldSortCorrectly()
        {
            var numbers = new List<int> { 5, 1, 3 };
            var sorted = numbers.OrderBySafe(x => x).ToList();
            Assert.Equal(new List<int> { 1, 3, 5 }, sorted);
        }

        [Fact]
        public void OrderByDescendingSafe_ShouldSortDescending()
        {
            var numbers = new List<int> { 5, 1, 3 };
            var sorted = numbers.OrderByDescendingSafe(x => x).ToList();
            Assert.Equal(new List<int> { 5, 3, 1 }, sorted);
        }

        [Fact]
        public void OrderBySafe_ShouldReturnEmptyForNull()
        {
            List<int>? nullList = null;
            var result = nullList!.OrderBySafe(x => x);
            Assert.Empty(result);
        }
    }
}