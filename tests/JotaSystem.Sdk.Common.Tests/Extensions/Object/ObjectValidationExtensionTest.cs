using JotaSystem.Sdk.Common.Extensions.Object;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Object
{
    public class ObjectValidationExtensionTest
    {
        [Fact]
        public void ThrowIfNull_ShouldThrowForNull()
        {
            object? obj = null;
            Assert.Throws<ArgumentNullException>(() => obj.ThrowIfNull(nameof(obj)));
        }

        [Fact]
        public void ThrowIfDefault_ShouldThrowForDefault()
        {
            int value = default;
            Assert.Throws<ArgumentException>(() => value.ThrowIfDefault(nameof(value)));
        }

        [Fact]
        public void Ensure_ShouldThrowWhenConditionIsFalse()
        {
            Assert.Throws<InvalidOperationException>(() => false.Ensure("Erro"));
        }
    }
}
