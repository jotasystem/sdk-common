using JotaSystem.Sdk.Common.Extensions.Http;
using System.Net.Http.Json;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Http
{
    public class HttpTimeoutExtensionTest
    {
        private class TestResponse { public int Value { get; set; } }

        [Fact]
        public async System.Threading.Tasks.Task GetWithTimeoutAsync_ShouldReturnDefaultOnTimeout()
        {
            using var client = new HttpClient(new DelayedHandler());
            var result = await client.GetWithTimeoutAsync<TestResponse>("https://fakeurl/test", System.TimeSpan.FromMilliseconds(10), new TestResponse { Value = -1 });
            Assert.Equal(-1, result!.Value);
        }

        [Fact]
        public async System.Threading.Tasks.Task PostWithTimeoutAsync_ShouldReturnDefaultOnTimeout()
        {
            using var client = new HttpClient(new DelayedHandler());
            var result = await client.PostWithTimeoutAsync<TestResponse>("https://fakeurl/test", new { X = 1 }, System.TimeSpan.FromMilliseconds(10), new TestResponse { Value = -1 });
            Assert.Equal(-1, result!.Value);
        }

        private class DelayedHandler : HttpMessageHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
            {
                await System.Threading.Tasks.Task.Delay(1000, cancellationToken);
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = JsonContent.Create(new TestResponse { Value = 123 }) };
            }
        }
    }
}