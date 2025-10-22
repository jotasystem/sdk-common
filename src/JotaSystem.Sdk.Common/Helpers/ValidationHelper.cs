namespace JotaSystem.Sdk.Common.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) &&
                   System.Text.RegularExpressions.Regex.IsMatch(email,
                   @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool IsNumeric(string value)
        {
            return double.TryParse(value, out _);
        }
    }
}
