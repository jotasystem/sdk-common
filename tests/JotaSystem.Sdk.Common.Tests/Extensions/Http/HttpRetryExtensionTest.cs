using JotaSystem.Sdk.Common.Extensions.Http;
using System.Net;
using System.Net.Http.Json;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Http
{
    public class HttpRetryExtensionTest
    {
        private class TestResponse { public int Value { get; set; } }

        [Fact]
        public async System.Threading.Tasks.Task RetryGetAsync_ShouldRetryAndReturnObject()
        {
            int attempts = 0;
            using var client = new HttpClient(new FuncHandler(req =>
            {
                attempts++;
                if (attempts < 2) throw new HttpRequestException();
                return System.Threading.Tasks.Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = JsonContent.Create(new TestResponse { Value = 42 }) });
            }));

            var result = await client.RetryGetAsync<TestResponse>("https://fakeurl/test", maxAttempts: 3);
            Assert.Equal(42, result!.Value);
            Assert.Equal(2, attempts);
        }

        [Fact]
        public async System.Threading.Tasks.Task RetryPostAsync_ShouldRetryAndReturnObject()
        {
            int attempts = 0;
            using var client = new HttpClient(new FuncHandler(req =>
            {
                attempts++;
                if (attempts < 2) throw new HttpRequestException();
                return System.Threading.Tasks.Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = JsonContent.Create(new TestResponse { Value = 99 }) });
            }));

            var result = await client.RetryPostAsync<TestResponse>("https://fakeurl/test", new { X = 1 }, maxAttempts: 3);
            Assert.Equal(99, result!.Value);
            Assert.Equal(2, attempts);
        }

        private class FuncHandler : HttpMessageHandler
        {
            private readonly Func<HttpRequestMessage, Task<HttpResponseMessage>> _func;
            public FuncHandler(Func<HttpRequestMessage, Task<HttpResponseMessage>> func) => _func = func;
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken) => _func(request);
        }
    }
}