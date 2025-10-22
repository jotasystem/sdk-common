using JotaSystem.Sdk.Common.Extensions.Collection;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Collection
{
    public class CollectionConversionExtensionTest
    {
        [Fact]
        public void ToHashSetSafe_ShouldReturnEmptyForNull()
        {
            List<int>? nullList = null;
            var set = nullList.ToHashSetSafe();
            Assert.NotNull(set);
            Assert.Empty(set);
        }

        [Fact]
        public void ToHashSetSafe_ShouldContainAllItems()
        {
            var numbers = new List<int> { 1, 2, 2, 3 };
            var set = numbers.ToHashSetSafe();
            Assert.Equal(3, set.Count);
        }

        [Fact]
        public void ToListSafe_ShouldReturnEmptyForNull()
        {
            List<int>? nullList = null;
            var list = nullList.ToListSafe();
            Assert.NotNull(list);
            Assert.Empty(list);
        }

        [Fact]
        public void ToListSafe_ShouldReturnCopyOfItems()
        {
            var numbers = new List<int> { 1, 2, 3 };
            var list = numbers.ToListSafe();
            Assert.Equal(numbers.Count, list.Count);
            Assert.Equal(numbers, list);
        }
    }
}