using System.Net.Http.Json;

namespace JotaSystem.Sdk.Common.Extensions.Http
{
    /// <summary>
    /// Métodos HTTP básicos (GET/POST/PUT/DELETE) com desserialização JSON.
    /// </summary>
    public static class HttpRequestExtension
    {
        /// <summary>
        /// Faz uma requisição GET e desserializa o JSON para o tipo T.
        /// </summary>
        /// <param name="client">HttpClient utilizado.</param>
        /// <param name="url">URL do endpoint.</param>
        /// <param name="cancellationToken">Token de cancelamento opcional.</param>
        /// <returns>Objeto do tipo T desserializado ou null.</returns>
        public static async Task<T?> GetAsync<T>(this HttpClient client, string url, CancellationToken cancellationToken = default)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));

            return await client.GetFromJsonAsync<T>(url, cancellationToken);
        }

        /// <summary>
        /// Faz uma requisição POST enviando um payload como JSON e retorna a resposta desserializada.
        /// </summary>
        /// <param name="client">HttpClient utilizado.</param>
        /// <param name="url">URL do endpoint.</param>
        /// <param name="payload">Objeto a ser enviado como JSON.</param>
        /// <param name="cancellationToken">Token de cancelamento opcional.</param>
        /// <returns>Objeto do tipo T desserializado ou null.</returns>
        public static async Task<T?> PostJsonAsync<T>(this HttpClient client, string url, object payload, CancellationToken cancellationToken = default)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (payload == null) throw new ArgumentNullException(nameof(payload));

            var response = await client.PostAsJsonAsync(url, payload, cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>(cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Faz uma requisição GET segura, retornando um valor default em caso de falha.
        /// </summary>
        /// <param name="client">HttpClient utilizado.</param>
        /// <param name="url">URL do endpoint.</param>
        /// <param name="defaultValue">Valor retornado em caso de erro.</param>
        /// <param name="cancellationToken">Token de cancelamento opcional.</param>
        /// <returns>Objeto do tipo T ou defaultValue.</returns>
        public static async Task<T?> TryGetAsync<T>(this HttpClient client, string url, T? defaultValue = default, CancellationToken cancellationToken = default)
        {
            try { return await client.GetAsync<T>(url, cancellationToken); }
            catch { return defaultValue; }
        }
    }
}