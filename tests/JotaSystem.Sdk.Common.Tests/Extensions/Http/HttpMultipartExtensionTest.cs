using JotaSystem.Sdk.Common.Extensions.Http;
using System.Net;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Http
{
    public class HttpMultipartExtensionTest
    {
        [Fact]
        public async System.Threading.Tasks.Task UploadFileAsync_ShouldReturnSuccess()
        {
            using var client = new HttpClient(new FakeHandler());
            using var stream = new MemoryStream(new byte[] { 1, 2, 3 });
            var response = await client.UploadFileAsync("https://fakeurl/upload", stream, "file.txt");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async System.Threading.Tasks.Task DownloadFileAsync_ShouldReturnBytes()
        {
            using var client = new HttpClient(new FuncHandler(req =>
                System.Threading.Tasks.Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(new byte[] { 1, 2, 3 }) })
            ));

            var bytes = await client.DownloadFileAsync("https://fakeurl/file");
            Assert.Equal(new byte[] { 1, 2, 3 }, bytes);
        }

        private class FakeHandler : HttpMessageHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
            {
                return System.Threading.Tasks.Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
            }
        }

        private class FuncHandler : HttpMessageHandler
        {
            private readonly System.Func<HttpRequestMessage, Task<HttpResponseMessage>> _func;
            public FuncHandler(System.Func<HttpRequestMessage, Task<HttpResponseMessage>> func) => _func = func;
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken) => _func(request);
        }
    }
}