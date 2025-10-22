using JotaSystem.Sdk.Common.Extensions.Collection;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Collection
{
    public class CollectionFilterExtensionTest
    {
        [Fact]
        public void WhereIf_ShouldApplyConditionally()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            var resultTrue = numbers.WhereIf(true, x => x > 3).ToList();
            Assert.Equal(new List<int> { 4, 5 }, resultTrue);

            var resultFalse = numbers.WhereIf(false, x => x > 3).ToList();
            Assert.Equal(numbers, resultFalse);
        }

        [Fact]
        public void FirstOrDefaultSafe_ShouldReturnDefaultForNull()
        {
            List<int>? nullList = null;
            Assert.Equal(default(int), nullList.FirstOrDefaultSafe());

            var list = new List<int> { 1, 2 };
            Assert.Equal(1, list.FirstOrDefaultSafe());
        }

        [Fact]
        public void DistinctByCustom_ShouldReturnUniqueByKey()
        {
            var people = new[]
            {
                new { Name = "Alice", Age = 20 },
                new { Name = "Bob", Age = 20 },
                new { Name = "Charlie", Age = 30 }
            };

            var distinct = people.DistinctByCustom(p => p.Age).ToList();
            Assert.Equal(2, distinct.Count);
            Assert.Contains(distinct, x => x.Name == "Alice");
            Assert.Contains(distinct, x => x.Name == "Charlie");
        }
    }
}