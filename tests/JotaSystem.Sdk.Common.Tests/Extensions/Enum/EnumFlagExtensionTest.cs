using JotaSystem.Sdk.Common.Extensions.Enum;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Enum
{
    [Flags]
    public enum TestFlagsEnum
    {
        None = 0,
        Flag1 = 1,
        Flag2 = 2,
        Flag3 = 4
    }

    public class EnumFlagExtensionTest
    {
        [Fact]
        public void HasFlagFast_ShouldReturnTrue_WhenFlagPresent()
        {
            var value = TestFlagsEnum.Flag1 | TestFlagsEnum.Flag3;
            Assert.True(value.HasFlagFast(TestFlagsEnum.Flag1));
            Assert.True(value.HasFlagFast(TestFlagsEnum.Flag3));
        }

        [Fact]
        public void HasFlagFast_ShouldReturnFalse_WhenFlagNotPresent()
        {
            var value = TestFlagsEnum.Flag1;
            Assert.False(value.HasFlagFast(TestFlagsEnum.Flag2));
        }

        [Fact]
        public void AddFlag_ShouldAddFlagCorrectly()
        {
            var value = TestFlagsEnum.Flag1;
            value = value.AddFlag(TestFlagsEnum.Flag2);
            Assert.True(value.HasFlagFast(TestFlagsEnum.Flag1));
            Assert.True(value.HasFlagFast(TestFlagsEnum.Flag2));
        }

        [Fact]
        public void RemoveFlag_ShouldRemoveFlagCorrectly()
        {
            var value = TestFlagsEnum.Flag1 | TestFlagsEnum.Flag2;
            value = value.RemoveFlag(TestFlagsEnum.Flag1);
            Assert.False(value.HasFlagFast(TestFlagsEnum.Flag1));
            Assert.True(value.HasFlagFast(TestFlagsEnum.Flag2));
        }

        [Fact]
        public void AddAndRemoveFlags_ShouldHandleMultipleFlags()
        {
            var value = TestFlagsEnum.None;
            value = value.AddFlag(TestFlagsEnum.Flag1 | TestFlagsEnum.Flag2);
            Assert.True(value.HasFlagFast(TestFlagsEnum.Flag1));
            Assert.True(value.HasFlagFast(TestFlagsEnum.Flag2));

            value = value.RemoveFlag(TestFlagsEnum.Flag1 | TestFlagsEnum.Flag3);
            Assert.False(value.HasFlagFast(TestFlagsEnum.Flag1));
            Assert.True(value.HasFlagFast(TestFlagsEnum.Flag2));
        }
    }
}