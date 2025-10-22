using JotaSystem.Sdk.Common.Extensions.Bool;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Bool
{
    public class BoolConversionExtensionTest
    {
        [Fact]
        public void ToYesNo_ShouldReturnCorrectString()
        {
            Assert.Equal("Sim", true.ToYesNo());
            Assert.Equal("Não", false.ToYesNo());
            Assert.Equal("Y", true.ToYesNo("Y", "N"));
            Assert.Equal("N", false.ToYesNo("Y", "N"));
        }

        [Fact]
        public void ToInt_ShouldReturn1Or0()
        {
            Assert.Equal(1, true.ToInt());
            Assert.Equal(0, false.ToInt());
        }

        [Fact]
        public void ToLowerString_ShouldReturnLowercase()
        {
            Assert.Equal("true", true.ToLowerString());
            Assert.Equal("false", false.ToLowerString());
        }

        [Fact]
        public void ToProperString_ShouldReturnCapitalized()
        {
            Assert.Equal("True", true.ToProperString());
            Assert.Equal("False", false.ToProperString());
        }

        [Fact]
        public void ToEmoji_ShouldReturnCorrectEmoji()
        {
            Assert.Equal("✔️", true.ToEmoji());
            Assert.Equal("❌", false.ToEmoji());
        }

        [Fact]
        public void ToBinaryString_ShouldReturn1Or0()
        {
            Assert.Equal("1", true.ToBinaryString());
            Assert.Equal("0", false.ToBinaryString());
        }

        [Fact]
        public void ToChar_ShouldReturnCorrectChar()
        {
            Assert.Equal('Y', true.ToChar('Y', 'N'));
            Assert.Equal('N', false.ToChar('Y', 'N'));
        }

        [Fact]
        public void ToByte_ShouldReturn1Or0()
        {
            Assert.Equal((byte)1, true.ToByte());
            Assert.Equal((byte)0, false.ToByte());
        }

        [Fact]
        public void ToSByte_ShouldReturn1Or0()
        {
            Assert.Equal((sbyte)1, true.ToSByte());
            Assert.Equal((sbyte)0, false.ToSByte());
        }
    }
}