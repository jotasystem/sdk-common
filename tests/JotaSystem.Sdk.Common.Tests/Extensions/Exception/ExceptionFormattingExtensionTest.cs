using JotaSystem.Sdk.Common.Extensions.Exception;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Exception
{
    public class ExceptionFormattingExtensionTest
    {
        [Fact]
        public void ToFullString_ShouldContainInnerExceptionMessages()
        {
            var inner = new InvalidOperationException("Inner error");
            var outer = new System.Exception("Outer error", inner);

            var full = outer.ToFullString();

            Assert.Contains("Outer error", full);
            Assert.Contains("Inner error", full);
        }

        [Fact]
        public void ToAllMessages_ShouldConcatenateInnerMessages()
        {
            var inner = new InvalidOperationException("Inner error");
            var outer = new System.Exception("Outer error", inner);

            var messages = outer.ToAllMessages();

            Assert.Equal("Outer error --> Inner error", messages);
        }
    }
}