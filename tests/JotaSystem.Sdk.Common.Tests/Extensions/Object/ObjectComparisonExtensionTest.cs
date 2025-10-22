using JotaSystem.Sdk.Common.Extensions.Object;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Object
{
    public class ObjectComparisonExtensionTest
    {
        [Fact]
        public void IsNull_ShouldReturnTrueForNull()
        {
            object? obj = null;
            Assert.True(obj.IsNull());
        }

        [Fact]
        public void IsNotNull_ShouldReturnTrueForNotNull()
        {
            object? obj = "";
            Assert.True(obj.IsNotNull());
        }

        [Fact]
        public void IsEqualTo_ShouldReturnTrueForEqualValues()
        {
            var a = 10;
            var b = 10;
            Assert.True(a.IsEqualTo(b));
        }

        [Fact]
        public void IsDefault_ShouldReturnTrueForDefaultValue()
        {
            int value = default;
            Assert.True(value.IsDefault());
        }
    }
}
