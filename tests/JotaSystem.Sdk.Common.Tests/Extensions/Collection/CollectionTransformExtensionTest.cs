using JotaSystem.Sdk.Common.Extensions.Collection;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Collection
{
    public class CollectionTransformExtensionTest
    {
        [Fact]
        public void ForEach_ShouldApplyAction()
        {
            var numbers = new List<int> { 1, 2, 3 };
            var sum = 0;
            numbers.ForEach(x => sum += x);
            Assert.Equal(6, sum);
        }

        [Fact]
        public void Chunk_ShouldDivideCollectionCorrectly()
        {
            var numbers = Enumerable.Range(1, 7).ToList();
            var chunks = numbers.ChunkSafe(3).ToList();

            Assert.Equal(3, chunks.Count);
            Assert.Equal(new List<int> { 1, 2, 3 }, chunks[0].ToList());
            Assert.Equal(new List<int> { 4, 5, 6 }, chunks[1].ToList());
            Assert.Equal(new List<int> { 7 }, chunks[2].ToList());
        }

        [Fact]
        public void ToDictionarySafe_ShouldIgnoreDuplicates()
        {
            var items = new[]
            {
                new { Id = 1, Name = "A" },
                new { Id = 1, Name = "B" },
                new { Id = 2, Name = "C" }
            };

            var dict = items.ToDictionarySafe(x => x.Id);
            Assert.Equal(2, dict.Count);
            Assert.Equal("A", dict[1].Name);
            Assert.Equal("C", dict[2].Name);
        }
    }
}