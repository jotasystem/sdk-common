namespace JotaSystem.Sdk.Common.Extensions.Guid
{
    /// <summary>
    /// Extensões para manipulação e validação de GUIDs.
    /// </summary>
    public static class GuidExtension
    {
        /// <summary>
        /// Verifica se o GUID é vazio.
        /// </summary>
        public static bool IsEmpty(this System.Guid guid) => guid == System.Guid.Empty;

        /// <summary>
        /// Tenta converter uma string em GUID de forma segura.
        /// </summary>
        public static bool TryParseGuid(this string value, out System.Guid guid) => System.Guid.TryParse(value, out guid);

        /// <summary>
        /// Retorna uma versão do GUID sem hífens.
        /// </summary>
        public static string ToShortString(this System.Guid guid) => guid.ToString("N");

        /// <summary>
        /// Gera um GUID sequencial (útil para bancos de dados).
        /// </summary>
        public static System.Guid GenerateSequentialGuid()
        {
            var guidArray = System.Guid.NewGuid().ToByteArray();
            var now = System.DateTime.UtcNow;
            var timestamp = BitConverter.GetBytes(now.Ticks);

            // sobrescreve os últimos 8 bytes com o timestamp
            for (int i = 0; i < 8; i++)
            {
                guidArray[i] = timestamp[i];
            }

            return new System.Guid(guidArray);
        }
    }
}