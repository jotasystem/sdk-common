namespace JotaSystem.Sdk.Common.Constants
{
    public static class AppConstants
    {
        // 🔹 Informações da aplicação
        public const string ApplicationName = "JotaSystemApp";
        public const string DefaultLanguage = "pt-BR";
        public const string DefaultCulture = "pt-BR";

        // 🔹 Tentativas / timeouts
        public const int MaxRetryAttempts = 3;
        public const int DefaultTimeoutSeconds = 30;

        // 🔹 Identificadores fixos
        public static readonly Guid SystemId = Guid.Parse("12345678-1234-1234-1234-123456789abc");
        public const string SystemUser = "SYSTEM";

        // 🔹 Configurações gerais
        public const int DefaultPageSize = 20;
        public const int MaxPageSize = 100;

        // 🔹 Formatos padrão
        public const string DefaultDateFormat = "dd/MM/yyyy";
        public const string DefaultDateTimeFormat = "dd/MM/yyyy HH:mm:ss";

        // 🔹 Flags / valores booleanos padrão
        public const bool DefaultIsActive = true;
        public const bool DefaultIsDeleted = false;

        // 🔹 Prefixos / códigos
        public const string DefaultCodePrefix = "JS-";
        public const string DefaultLogPrefix = "[JOTA_SYSTEM]";

        // 🔹 Limites gerais
        public const int MaxFileSizeMb = 50; // Tamanho máximo de arquivo
        public const int MaxFileNameLength = 255;

        // 🔹 Outros valores comuns
        public const string DefaultTimeZone = "America/Sao_Paulo";
        public const string DefaultCurrency = "BRL";
    }
}