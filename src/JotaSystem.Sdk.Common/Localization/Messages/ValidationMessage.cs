namespace JotaSystem.Sdk.Common.Localization.Messages
{
    public static class ValidationMessage
    {
        public static string RequiredField(string fieldName, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.EnUs => $"{fieldName} cannot be empty.",
                Language.EsEs => $"{fieldName} no puede estar vacío.",
                _ => $"{fieldName} não pode ser vazio."
            };

        public static string InvalidField(string fieldName, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.EnUs => $"{fieldName} is invalid.",
                Language.EsEs => $"{fieldName} es inválido.",
                _ => $"{fieldName} é inválido."
            };

        public static string InvalidFormat(string fieldName, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.EnUs => $"{fieldName} has an invalid format.",
                Language.EsEs => $"{fieldName} tiene un formato inválido.",
                _ => $"{fieldName} possui um formato inválido."
            };

        public static string MinLength(string fieldName, int minlength, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.EnUs => $"{fieldName} must at minimum {minlength} characters.",
                Language.EsEs => $"{fieldName} debe tener al menos {minlength} caracteres.",
                _ => $"{fieldName} deve ter no mínimo {minlength} caracteres."
            };

        public static string MaxLength(string fieldName, int maxlength, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.EnUs => $"{fieldName} must at maximum {maxlength} characters.",
                Language.EsEs => $"{fieldName} debe tener al máximo {maxlength} caracteres.",
                _ => $"{fieldName} deve ter no máximo {maxlength} caracteres."
            };

        public static string InvalidLength(string fieldName, int expectedLength, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.EnUs => $"{fieldName} must have {expectedLength} characters.",
                Language.EsEs => $"{fieldName} debe tener {expectedLength} caracteres.",
                _ => $"{fieldName} deve ter {expectedLength} caracteres."
            };

        public static string LengthOutOfRange(string fieldName, int minLength, int maxLength, Language? lang = null) =>
            LanguageProvider.Use(lang) switch
            {
                Language.EnUs => $"{fieldName} must have between {minLength} and {maxLength} characters.",
                Language.EsEs => $"{fieldName} debe tener entre {minLength} y {maxLength} caracteres.",
                _ => $"{fieldName} deve ter entre {minLength} e {maxLength} caracteres."
            };
    }
}