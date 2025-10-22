using JotaSystem.Sdk.Common.Extensions.String;
using System.Web;

namespace JotaSystem.Sdk.Common.Helpers
{
    /// <summary>
    /// Helper para operações com URLs.
    /// </summary>
    public static class UrlHelper
    {
        /// <summary>
        /// Verifica se uma URL é válida.
        /// </summary>
        /// <param name="url">URL a ser verificada.</param>
        /// <returns>True se a URL é válida; false caso contrário.</returns>
        public static bool IsValidUrl(string url) => url.IsUrl();

        /// <summary>
        /// Adiciona parâmetros de query a uma URL existente.
        /// </summary>
        /// <param name="url">URL base.</param>
        /// <param name="parameters">Parâmetros a serem adicionados.</param>
        /// <returns>URL completa com parâmetros de query.</returns>
        public static string AddQueryParameters(string url, IDictionary<string, string> parameters)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("O URL não pode ser nulo ou vazio.", nameof(url));

            if (parameters == null || parameters.Count == 0)
                return url;

            var uri = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uri.Query);

            foreach (var kvp in parameters)
            {
                query[kvp.Key] = kvp.Value;
            }

            uri.Query = query.ToString() ?? string.Empty;
            return uri.ToString();
        }

        /// <summary>
        /// Retorna o domínio (host) de uma URL.
        /// </summary>
        /// <param name="url">URL completa.</param>
        /// <returns>Dominio/host da URL.</returns>
        public static string GetDomain(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("O URL não pode ser nulo ou vazio.", nameof(url));

            if (!Uri.TryCreate(url, UriKind.Absolute, out var uriResult))
                throw new ArgumentException("O URL fornecido é inválido.", nameof(url));

            return uriResult.Host;
        }
    }
}