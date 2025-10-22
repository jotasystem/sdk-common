using JotaSystem.Sdk.Common.Extensions.String;

namespace JotaSystem.Sdk.Common.Tests.Extensions.String
{
    public class StringEncodingExtensionTest
    {
        [Fact]
        public void ToBase64_And_FromBase64_ShouldWorkCorrectly()
        {
            string original = "Olá Mundo";
            string encoded = original.ToBase64();
            string decoded = encoded.FromBase64();
            Assert.Equal(original, decoded);
        }

        [Fact]
        public void ToAscii_ShouldRemoveAccents()
        {
            string result = "áéíóú çãõ".ToAscii();
            Assert.Equal("aeiou cao", result);
        }

        [Fact]
        public void ToMd5_ShouldReturnConsistentHash()
        {
            string value = "abc123";
            string hash1 = value.ToMd5();
            string hash2 = value.ToMd5();
            Assert.Equal(hash1, hash2);
            Assert.Equal(32, hash1.Length);
        }

        [Fact]
        public void ToSha256_ShouldReturnConsistentHash()
        {
            string value = "abc123";
            string hash1 = value.ToSha256();
            string hash2 = value.ToSha256();
            Assert.Equal(hash1, hash2);
            Assert.Equal(64, hash1.Length);
        }
    }
}
