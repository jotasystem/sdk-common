namespace JotaSystem.Sdk.Common.Extensions.Http
{
    /// <summary>
    /// Extensões HTTP com retry automático.
    /// </summary>
    public static class HttpRetryExtension
    {
        /// <summary>
        /// Executa uma requisição GET com retry automático em caso de falha.
        /// </summary>
        /// <param name="client">HttpClient utilizado.</param>
        /// <param name="url">URL do endpoint.</param>
        /// <param name="maxAttempts">Número máximo de tentativas.</param>
        /// <param name="delay">Delay entre tentativas.</param>
        /// <param name="defaultValue">Valor retornado em caso de falha.</param>
        /// <returns>Objeto do tipo T ou defaultValue.</returns>
        public static async Task<T?> RetryGetAsync<T>(this HttpClient client, string url, int maxAttempts = 3, TimeSpan? delay = null, T? defaultValue = default)
        {
            if (delay == null) delay = TimeSpan.FromMilliseconds(500);

            for (int i = 0; i < maxAttempts; i++)
            {
                try { return await client.GetAsync<T>(url); }
                catch when (i < maxAttempts - 1) { await System.Threading.Tasks.Task.Delay(delay.Value); }
            }

            return defaultValue;
        }

        /// <summary>
        /// Executa uma requisição POST com retry automático em caso de falha.
        /// </summary>
        /// <param name="client">HttpClient utilizado.</param>
        /// <param name="url">URL do endpoint.</param>
        /// <param name="payload">Objeto a ser enviado como JSON.</param>
        /// <param name="maxAttempts">Número máximo de tentativas.</param>
        /// <param name="delay">Delay entre tentativas.</param>
        /// <param name="defaultValue">Valor retornado em caso de falha.</param>
        /// <returns>Objeto do tipo T ou defaultValue.</returns>
        public static async Task<T?> RetryPostAsync<T>(this HttpClient client, string url, object payload, int maxAttempts = 3, TimeSpan? delay = null, T? defaultValue = default)
        {
            if (delay == null) delay = TimeSpan.FromMilliseconds(500);

            for (int i = 0; i < maxAttempts; i++)
            {
                try { return await client.PostJsonAsync<T>(url, payload); }
                catch when (i < maxAttempts - 1) { await System.Threading.Tasks.Task.Delay(delay.Value); }
            }

            return defaultValue;
        }
    }
}