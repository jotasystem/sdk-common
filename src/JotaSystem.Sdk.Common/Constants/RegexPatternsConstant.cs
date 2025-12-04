namespace JotaSystem.Sdk.Common.Constants
{
    public static class RegexPatternsConstant
    {
        // 🔹 E-mail
        public const string Email = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        // 🔹 CPF / CNPJ
        public const string Cpf = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";
        public const string Cnpj = @"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$";

        // 🔹 Telefones
        public const string Phone = @"^\(?\d{2}\)?[\s-]?[\d\s-]{8,9}$"; // Brasil
        public const string PhoneWithCountryCode = @"^\+?\d{1,3}?[-.\s]?\(?\d{1,4}?\)?([-.\s]?\d{1,4}){1,3}$"; // Internacional

        // 🔹 Somente números / letras
        public const string OnlyNumbers = @"^\d+$";
        public const string OnlyLetters = @"^[A-Za-z]+$";
        public const string LettersAndNumbers = @"^[A-Za-z0-9]+$";
        public const string LettersNumbersSpaces = @"^[A-Za-z0-9\s]+$";

        // 🔹 Senhas (mínimo 6 caracteres, ao menos 1 letra e 1 número)
        public const string PasswordSimple = @"^(?=.*[A-Za-z])(?=.*\d).{6,}$";

        // 🔹 CEP (Brasil)
        public const string Cep = @"^\d{5}-?\d{3}$";

        // 🔹 URL
        public const string Url = @"^(https?:\/\/)?([\w\-]+\.)+[\w\-]+(\/[\w\-._~:/?#[\]@!$&'()*+,;=]*)?$";

        // 🔹 IP
        public const string IpV4 = @"^(25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)){3}$";
        public const string IpV6 = @"^([0-9a-fA-F]{1,4}:){7}[0-9a-fA-F]{1,4}$";

        // 🔹 Data em formato dd/MM/yyyy
        public const string Date = @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$";

        // 🔹 Horas HH:mm ou HH:mm:ss
        public const string Time = @"^([01]\d|2[0-3]):([0-5]\d)(:([0-5]\d))?$";

        // 🔹 UUID / GUID
        public const string Guid = @"^[{(]?[0-9a-fA-F]{8}(-[0-9a-fA-F]{4}){3}-[0-9a-fA-F]{12}[)}]?$";

        // 🔹 Base64
        public const string Base64 = @"^(?:[A-Za-z0-9+\/]{4})*(?:[A-Za-z0-9+\/]{2}==|[A-Za-z0-9+\/]{3}=)?$";
    }
}