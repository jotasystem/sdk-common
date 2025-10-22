namespace JotaSystem.Sdk.Common.Helpers
{
    /// <summary>
    /// Helper para operações simples com arquivos.
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Verifica se um arquivo existe no caminho especificado.
        /// </summary>
        public static bool Exists(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("O caminho não pode ser nulo ou vazio.", nameof(path));

            return File.Exists(path);
        }

        /// <summary>
        /// Cria o arquivo caso ele não exista.
        /// </summary>
        public static void CreateIfNotExists(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("O caminho não pode ser nulo ou vazio.", nameof(path));

            if (!File.Exists(path))
                File.Create(path).Dispose();
        }

        /// <summary>
        /// Lê o conteúdo de um arquivo. Retorna string vazia se não existir.
        /// </summary>
        public static string ReadFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("O caminho não pode ser nulo ou vazio.", nameof(path));

            return File.Exists(path) ? File.ReadAllText(path) : string.Empty;
        }

        /// <summary>
        /// Escreve conteúdo em um arquivo. Sobrescreve caso já exista.
        /// </summary>
        public static void WriteFile(string path, string content)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("O caminho não pode ser nulo ou vazio.", nameof(path));

            content ??= string.Empty;

            File.WriteAllText(path, content);
        }
    }
}