using JotaSystem.Sdk.Common.Helpers;

namespace JotaSystem.Sdk.Common.Tests.Helpers
{
    public class DocumentHelperTest
    {
        [Fact]
        public void IsCpf_ShouldValidateCpf()
        {
            Assert.True(DocumentHelper.IsValidCpf("52998224725"));
        }

        [Fact]
        public void IsCpf_ShouldInvalidateCpf()
        {
            Assert.False(DocumentHelper.IsValidCpf("12345678900"));
        }

        [Fact]
        public void IsCnpj_ShouldValidateCnpj()
        {
            Assert.True(DocumentHelper.IsValidCnpj("11444777000161"));
        }

        [Fact]
        public void IsCpf_ShouldInvalidateCnpj()
        {
            Assert.False(DocumentHelper.IsValidCnpj("112223330001812"));
        }

        [Fact]
        public void FormatCpf_ShouldValidateCpf()
        {
            Assert.Equal("398.476.230-58", DocumentHelper.FormatCpf("39847623058"));
        }

        [Fact]
        public void FormatCnpj_ShouldValidateCpf()
        {
            Assert.Equal("46.320.677/0001-08", DocumentHelper.FormatCnpj("46320677000108"));
        }
    }
}