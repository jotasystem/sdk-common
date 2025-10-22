using JotaSystem.Sdk.Common.Extensions.Exception;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Exception
{
    public class ExceptionUnwrapExtensionTest
    {
        [Fact]
        public void GetInnermostException_ShouldReturnMostInnerException()
        {
            var inner = new InvalidOperationException("Inner");
            var middle = new System.Exception("Middle", inner);
            var outer = new System.Exception("Outer", middle);

            var result = outer.GetInnermostException();

            Assert.Equal(inner, result);
        }
    }
}