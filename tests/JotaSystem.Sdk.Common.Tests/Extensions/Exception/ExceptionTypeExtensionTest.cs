using JotaSystem.Sdk.Common.Extensions.Exception;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Exception
{
    public class ExceptionTypeExtensionTest
    {
        [Fact]
        public void IsOfType_ShouldReturnTrue_WhenInnerIsOfType()
        {
            var inner = new InvalidOperationException();
            var outer = new System.Exception("Outer", inner);

            Assert.True(outer.IsOfType<InvalidOperationException>());
        }


        [Fact]
        public void IsOfType_ShouldReturnFalse_WhenTypeDoesNotMatch()
        {
            var ex = new System.Exception("Error");
            Assert.False(ex.IsOfType<InvalidOperationException>());
        }


        [Fact]
        public void IsTimeout_ShouldReturnTrue_ForTimeoutException()
        {
            var ex = new TimeoutException();
            Assert.True(ex.IsTimeout());
        }
    }
}