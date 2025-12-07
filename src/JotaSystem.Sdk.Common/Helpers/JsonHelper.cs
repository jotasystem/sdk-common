using System.Text.Json;

namespace JotaSystem.Sdk.Common.Helpers
{
    public static class JsonHelper
    {
        private static readonly JsonSerializerOptions _options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };

        /// <summary>
        /// Desserializa o JSON em T, retornando ApiResponse com sucesso ou erro.
        /// </summary>
        public static T? Deserialize<T>(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                throw new Exception("JSON vazio ou nulo.");

            try
            {
                var obj = JsonSerializer.Deserialize<T>(json, _options);
                return obj == null ? throw new Exception("Falha ao desserializar JSON: objeto nulo.") : obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Serializa o objeto em JSON camelCase.
        /// </summary>
        public static string Serialize(object obj)
        {
            if (obj == null)
                return string.Empty;

            try
            {
                return JsonSerializer.Serialize(obj, _options);
            }
            catch
            {
                return string.Empty; // fallback silencioso
            }
        }
    }
}