using System.Text.Json;

namespace JotaSystem.Sdk.Common.Extensions.Json
{
    /// <summary>
    /// Extensões para serialização e desserialização de objetos em JSON.
    /// </summary>
    public static class JsonExtension
    {
        /// <summary>
        /// Serializa um objeto em JSON.
        /// </summary>
        /// <param name="obj">Objeto a ser serializado.</param>
        /// <param name="indented">Se deve ser formatado com identação.</param>
        /// <returns>String JSON.</returns>
        public static string ToJson(this object obj, bool indented = false)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            var options = new JsonSerializerOptions
            {
                WriteIndented = indented,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            return JsonSerializer.Serialize(obj, options);
        }

        /// <summary>
        /// Desserializa JSON em objeto do tipo T.
        /// </summary>
        public static T FromJson<T>(this string json)
        {
            if (string.IsNullOrWhiteSpace(json)) throw new ArgumentNullException(nameof(json));
            return JsonSerializer.Deserialize<T>(json) ?? throw new InvalidOperationException("Unable to deserialize JSON.");
        }

        /// <summary>
        /// Tenta desserializar JSON de forma segura, retornando false em caso de falha.
        /// </summary>
        public static bool TryFromJson<T>(this string json, out T? result)
        {
            result = default;
            if (string.IsNullOrWhiteSpace(json)) return false;


            try
            {
                result = JsonSerializer.Deserialize<T>(json);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Cria uma cópia profunda de um objeto utilizando JSON.
        /// </summary>
        public static T CloneJson<T>(this T obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            var json = obj.ToJson();
            return json.FromJson<T>();
        }

        /// <summary>
        /// Formata uma string JSON para ficar legível.
        /// </summary>
        public static string PrettyPrint(this string json)
        {
            if (string.IsNullOrWhiteSpace(json)) return string.Empty;


            try
            {
                using var doc = JsonDocument.Parse(json);
                return JsonSerializer.Serialize(doc, new JsonSerializerOptions { WriteIndented = true });
            }
            catch
            {
                return json; // retorna original se não for JSON válido
            }
        }
    }
}