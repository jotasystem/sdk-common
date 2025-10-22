using JotaSystem.Sdk.Common.Extensions.Http;
using System.Net.Http.Json;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Http
{
    public class HttpRequestExtensionTest
    {
        private class TestResponse { public int Value { get; set; } }

        [Fact]
        public async System.Threading.Tasks.Task GetAsync_ShouldReturnObject()
        {
            using var client = new HttpClient(new FakeHandler());
            var result = await client.GetAsync<TestResponse>("https://fakeurl/test");
            Assert.Equal(123, result!.Value);
        }

        [Fact]
        public async System.Threading.Tasks.Task PostJsonAsync_ShouldReturnObject()
        {
            using var client = new HttpClient(new FakeHandler());
            var result = await client.PostJsonAsync<TestResponse>("https://fakeurl/test", new { X = 1 });
            Assert.Equal(123, result!.Value);
        }

        [Fact]
        public async System.Threading.Tasks.Task TryGetAsync_ShouldReturnDefaultOnFailure()
        {
            using var client = new HttpClient(new FailingHandler());
            var result = await client.TryGetAsync<TestResponse>("https://fakeurl/test", new TestResponse { Value = -1 });
            Assert.Equal(-1, result!.Value);
        }

        private class FakeHandler : HttpMessageHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
            {
                return System.Threading.Tasks.Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = JsonContent.Create(new TestResponse { Value = 123 }) });
            }
        }

        private class FailingHandler : HttpMessageHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
            {
                throw new HttpRequestException();
            }
        }
    }
}