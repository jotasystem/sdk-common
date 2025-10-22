using JotaSystem.Sdk.Common.Extensions.Reflection;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Reflection
{
    public class ReflectionTypeExtensionTest
    {
        [Fact]
        public void IsNullableType_ShouldReturnTrue_ForNullable()
        {
            Assert.True(typeof(int?).IsNullableType());
            Assert.False(typeof(int).IsNullableType());
        }

        [Fact]
        public void IsEnumerableType_ShouldDetectCollections()
        {
            Assert.True(typeof(List<int>).IsEnumerableType());
            Assert.False(typeof(string).IsEnumerableType());
        }

        [Fact]
        public void IsAnonymousType_ShouldDetectAnonymous()
        {
            var anon = new { X = 1 };
            Assert.True(anon.GetType().IsAnonymousType());
            Assert.False(typeof(string).IsAnonymousType());
        }

        [Fact]
        public void GetUnderlyingType_ShouldReturnCorrectType()
        {
            Assert.Equal(typeof(int), typeof(int?).GetUnderlyingType());
            Assert.Equal(typeof(int), typeof(int).GetUnderlyingType());
        }
    }
}