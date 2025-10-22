namespace JotaSystem.Sdk.Common.Helpers
{
    public static class FileHelper
    {
        public static bool Exists(string path) => File.Exists(path);

        public static void CreateIfNotExists(string path)
        {
            if (!File.Exists(path))
                File.Create(path).Dispose();
        }

        public static string ReadFile(string path)
        {
            return File.Exists(path) ? File.ReadAllText(path) : string.Empty;
        }

        public static void WriteFile(string path, string content)
        {
            File.WriteAllText(path, content);
        }
    }
}