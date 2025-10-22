using JotaSystem.Sdk.Common.Extensions.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Object
{
    public class ObjectConversionExtensionTest
    {
        [Fact]
        public void ToOrDefault_ShouldConvertStringToInt()
        {
            object value = "42";
            Assert.Equal(42, value.ToOrDefault<int>());
        }

        [Fact]
        public void TryCast_ShouldReturnDefaultForIncompatibleType()
        {
            object value = "abc";
            Assert.Equal(default(int), value.TryCast<int>());
        }

        [Fact]
        public void TryCast_ShouldReturnValueForCompatibleType()
        {
            object value = 99;
            Assert.Equal(99, value.TryCast<int>());
        }

        [Fact]
        public void DeepClone_ShouldCreateNewInstance()
        {
            var original = new { Name = "Jota" };
            var clone = original.DeepClone();
            Assert.NotSame(original, clone);
            Assert.Equal(original.Name, clone?.Name);
        }
    }
}
