using System.Net.Http.Headers;

namespace JotaSystem.Sdk.Common.Extensions.Http
{
    /// <summary>
    /// Extensões HTTP para upload/download multipart e streaming.
    /// </summary>
    public static class HttpMultipartExtension
    {
        /// <summary>
        /// Faz upload de um arquivo via POST multipart/form-data.
        /// </summary>
        /// <param name="client">HttpClient utilizado.</param>
        /// <param name="url">URL do endpoint.</param>
        /// <param name="fileStream">Stream do arquivo a ser enviado.</param>
        /// <param name="fileName">Nome do arquivo.</param>
        /// <param name="contentName">Nome do campo multipart (default: \"file\").</param>
        /// <param name="cancellationToken">Token de cancelamento opcional.</param>
        /// <returns>HttpResponseMessage retornado pelo servidor.</returns>
        public static async Task<HttpResponseMessage> UploadFileAsync(this HttpClient client, string url, Stream fileStream, string fileName, string contentName = "file", CancellationToken cancellationToken = default)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (fileStream == null) throw new ArgumentNullException(nameof(fileStream));
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullException(nameof(fileName));

            using var content = new MultipartFormDataContent();
            content.Add(new StreamContent(fileStream) { Headers = { ContentType = new MediaTypeHeaderValue("application/octet-stream") } }, contentName, fileName);
            return await client.PostAsync(url, content, cancellationToken);
        }

        /// <summary>
        /// Faz download de um arquivo retornando os bytes.
        /// </summary>
        /// <param name="client">HttpClient utilizado.</param>
        /// <param name="url">URL do arquivo.</param>
        /// <param name="cancellationToken">Token de cancelamento opcional.</param>
        /// <returns>Array de bytes do arquivo.</returns>
        public static async Task<byte[]> DownloadFileAsync(this HttpClient client, string url, CancellationToken cancellationToken = default)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));

            return await client.GetByteArrayAsync(url, cancellationToken);
        }
    }
}