namespace JotaSystem.Sdk.Common.Localization.Messages
{
    public static class ValidationMessage
    {
        public static string RequiredField(string fieldName, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.En => $"{fieldName} cannot be empty.",
                Language.Es => $"{fieldName} no puede estar vacío.",
                _ => $"{fieldName} não pode ser vazio."
            };

        public static string InvalidField(string fieldName, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.En => $"{fieldName} is invalid.",
                Language.Es => $"{fieldName} es inválido.",
                _ => $"{fieldName} é inválido."
            };

        public static string InvalidFormat(string fieldName, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.En => $"{fieldName} has an invalid format.",
                Language.Es => $"{fieldName} tiene un formato inválido.",
                _ => $"{fieldName} possui um formato inválido."
            };

        public static string InvalidLength(string fieldName, int expectedLength, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.En => $"{fieldName} must have {expectedLength} characters.",
                Language.Es => $"{fieldName} debe tener {expectedLength} caracteres.",
                _ => $"{fieldName} deve ter {expectedLength} caracteres."
            };

        public static string LengthOutOfRange(string fieldName, int minLength, int maxLength, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.En => $"{fieldName} must have between {minLength} and {maxLength} characters.",
                Language.Es => $"{fieldName} debe tener entre {minLength} y {maxLength} caracteres.",
                _ => $"{fieldName} deve ter entre {minLength} e {maxLength} caracteres."
            };
    }
}