using JotaSystem.Sdk.Common.Extensions.Guid;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Guid
{
    public class GuidExtensionTest
    {
        [Fact]
        public void IsEmpty_ShouldDetectEmptyGuid()
        {
            Assert.True(System.Guid.Empty.IsEmpty());
            Assert.False(System.Guid.NewGuid().IsEmpty());
        }

        [Fact]
        public void TryParseGuid_ShouldParseCorrectly()
        {
            var str = "d2719a0c-ff34-4f1e-a8f5-1d2c8d3f6a12";
            Assert.True(str.TryParseGuid(out var guid));
            Assert.Equal(str, guid.ToString());


            var invalid = "not-a-guid";
            Assert.False(invalid.TryParseGuid(out _));
        }

        [Fact]
        public void ToShortString_ShouldReturnWithoutHyphens()
        {
            var guid = System.Guid.NewGuid();
            var shortStr = guid.ToShortString();
            Assert.Equal(32, shortStr.Length);
            Assert.DoesNotContain("-", shortStr);
        }

        [Fact]
        public void GenerateSequentialGuid_ShouldReturnUniqueGuids()
        {
            var g1 = GuidExtension.GenerateSequentialGuid();
            Thread.Sleep(1);

            var g2 = GuidExtension.GenerateSequentialGuid();
            Assert.NotEqual(g1, g2);
        }
    }
}