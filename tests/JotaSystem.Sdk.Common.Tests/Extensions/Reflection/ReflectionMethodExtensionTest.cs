using JotaSystem.Sdk.Common.Extensions.Reflection;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Reflection
{
    public class ReflectionMethodExtensionTest
    {
        private class TestObj
        {
            public int Add(int x, int y) => x + y;
            public string SayHello(string name) => $"Hello {name}";
        }

        [Fact]
        public void InvokeMethod_ShouldReturnCorrectResult()
        {
            var obj = new TestObj();
            var sum = obj.InvokeMethod("Add", 2, 3);
            var msg = obj.InvokeMethod("SayHello", "Jota");

            Assert.Equal(5, sum);
            Assert.Equal("Hello Jota", msg);
        }

        [Fact]
        public void TryInvokeMethod_ShouldReturnDefault_OnException()
        {
            var obj = new TestObj();
            var result = obj.TryInvokeMethod<int>("NonExistingMethod");
            Assert.Equal(default(int), result);
        }
    }
}