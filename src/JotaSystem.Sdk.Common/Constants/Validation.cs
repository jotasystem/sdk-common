namespace JotaSystem.Sdk.Common.Constants
{
    public static class Validation
    {
        // 🔹 Comprimentos de campos de texto
        public const int MaxNameLength = 150;
        public const int MinNameLength = 2;

        public const int MaxEmailLength = 100;
        public const int MinEmailLength = 5;

        public const int MaxPasswordLength = 50;
        public const int MinPasswordLength = 6;

        public const int MaxUsernameLength = 50;
        public const int MinUsernameLength = 3;

        public const int MaxDescriptionLength = 500;
        public const int MinDescriptionLength = 5;

        public const int MaxTitleLength = 200;
        public const int MinTitleLength = 2;

        // 🔹 Geolocalização
        public const decimal MinLatitude = -90.0m;
        public const decimal MaxLatitude = 90.0m;

        public const decimal MinLongitude = -180.0m;
        public const decimal MaxLongitude = 180.0m;

        // 🔹 Valores numéricos
        public const int MaxPageSize = 100; // Para paginação
        public const int MinPageSize = 1;

        public const int MaxQuantity = 10000;
        public const int MinQuantity = 0;

        public const decimal MaxPrice = 1000000m;
        public const decimal MinPrice = 0m;

        // 🔹 Medidas físicas (genéricas)
        public const decimal MinWeightKg = 0.0m;
        public const decimal MaxWeightKg = 10000.0m;

        public const decimal MinHeightCm = 0.0m;
        public const decimal MaxHeightCm = 500.0m;

        public const decimal MinWidthCm = 0.0m;
        public const decimal MaxWidthCm = 500.0m;

        public const decimal MinLengthCm = 0.0m;
        public const decimal MaxLengthCm = 500.0m;

        // 🔹 Outros limites úteis
        public const int MaxPhoneLength = 20;
        public const int MinPhoneLength = 8;

        public const int MaxZipCodeLength = 10;
        public const int MinZipCodeLength = 8;

        public const int MaxCodeLength = 20;
        public const int MinCodeLength = 1;
    }
}