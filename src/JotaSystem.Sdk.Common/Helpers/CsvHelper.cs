using System.Text;

namespace JotaSystem.Sdk.Common.Helpers
{
    public static class CsvHelper
    {
        public static string ExportToCsv<T>(IEnumerable<T> data, string separator = ";")
        {
            var properties = typeof(T).GetProperties();

            var csv = new StringBuilder();

            // Cabeçalho
            csv.AppendLine(string.Join(separator, properties.Select(p => p.Name)));

            // Linhas
            foreach (var item in data)
            {
                var values = properties.Select(p =>
                {
                    var value = p.GetValue(item) ?? "";
                    return value.ToString()!.Replace(separator, " ");
                });

                csv.AppendLine(string.Join(separator, values));
            }

            return csv.ToString();
        }
    }
}