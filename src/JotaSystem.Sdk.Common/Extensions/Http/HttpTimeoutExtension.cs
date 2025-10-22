using System.Net.Http.Json;

namespace JotaSystem.Sdk.Common.Extensions.Http
{
    /// <summary>
    /// Extensões HTTP com timeout e cancelamento.
    /// </summary>
    public static class HttpTimeoutExtension
    {
        /// <summary>
        /// Executa uma requisição GET com timeout configurável.
        /// </summary>
        /// <param name="client">HttpClient utilizado.</param>
        /// <param name="url">URL do endpoint.</param>
        /// <param name="timeout">Tempo máximo de espera.</param>
        /// <param name="defaultValue">Valor retornado em caso de timeout ou falha.</param>
        /// <returns>Objeto do tipo T ou defaultValue.</returns>
        public static async Task<T?> GetWithTimeoutAsync<T>(this HttpClient client, string url, TimeSpan timeout, T? defaultValue = default)
        {
            using var cts = new CancellationTokenSource(timeout);
            try { return await client.GetFromJsonAsync<T>(url, cts.Token); }
            catch { return defaultValue; }
        }

        /// <summary>
        /// Executa uma requisição POST com timeout configurável.
        /// </summary>
        /// <param name="client">HttpClient utilizado.</param>
        /// <param name="url">URL do endpoint.</param>
        /// <param name="payload">Objeto a ser enviado como JSON.</param>
        /// <param name="timeout">Tempo máximo de espera.</param>
        /// <param name="defaultValue">Valor retornado em caso de timeout ou falha.</param>
        /// <returns>Objeto do tipo T ou defaultValue.</returns>
        public static async Task<T?> PostWithTimeoutAsync<T>(this HttpClient client, string url, object payload, TimeSpan timeout, T? defaultValue = default)
        {
            using var cts = new CancellationTokenSource(timeout);
            try
            {
                var response = await client.PostAsJsonAsync(url, payload, cts.Token);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>(cancellationToken: cts.Token);
            }
            catch { return defaultValue; }
        }
    }
}