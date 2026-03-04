namespace JotaSystem.Sdk.Common.Constants
{
    public static class MaskPatternsConstant
    {
        // 🔹 Documentos
        public const string Cpf = "000.000.000-00";
        public const string Cnpj = "00.000.000/0000-00";
        public const string CpfCnpj = "000.000.000-00|00.000.000/0000-00";

        // 🔹 Telefones
        public const string Phone = "(00) 0000-0000";
        public const string Mobile = "(00) 00000-0000";
        public const string PhoneOrMobile = "(00) 0000-0000|(00) 00000-0000";

        // 🔹 Endereço
        public const string Cep = "00000-000";

        // 🔹 Datas
        public const string Date = "00/00/0000";
        public const string DateTime = "00/00/0000 00:00";
        public const string Time = "00:00";
        public const string TimeWithSeconds = "00:00:00";

        // 🔹 Financeiro
        public const string Currency = "000.000.000,00";
        public const string Percentage = "000%";

        // 🔹 Identificação
        public const string Guid = "********-****-****-****-************";

        // 🔹 Placa Mercosul
        public const string LicensePlate = "AAA0A00";

        // 🔹 Cartão de crédito
        public const string CreditCard = "0000 0000 0000 0000";
        public const string CreditCardExpiration = "00/00";
        public const string CreditCardCvv = "000";
    }
}