namespace JotaSystem.Sdk.Common.Extensions.Bool
{
    /// <summary>
    /// Extensões para conversão de valores booleanos em representações textuais ou numéricas.
    /// </summary>
    public static class BoolConversionExtension
    {
        /// <summary>
        /// Converte o valor em "Sim" ou "Não" (padrão pt-BR) ou textos personalizados.
        /// </summary>
        public static string ToYesNo(this bool value, string trueText = "Sim", string falseText = "Não")
            => value ? trueText : falseText;

        /// <summary>
        /// Converte o valor booleano em inteiro (1 ou 0).
        /// </summary>
        public static int ToInt(this bool value) => value ? 1 : 0;

        /// <summary>
        /// Converte o valor em string minúscula ("true"/"false").
        /// </summary>
        public static string ToLowerString(this bool value)
            => value ? "true" : "false";

        /// <summary>
        /// Converte o valor em string com primeira letra maiúscula ("True"/"False").
        /// </summary>
        public static string ToProperString(this bool value)
            => value ? "True" : "False";

        /// <summary>
        /// Converte o valor em emoji ✔️ ou ❌.
        /// </summary>
        public static string ToEmoji(this bool value)
            => value ? "✔️" : "❌";

        /// <summary>
        /// Converte o valor em string binária "1" ou "0".
        /// </summary>
        public static string ToBinaryString(this bool value) => value ? "1" : "0";

        /// <summary>
        /// Converte o valor em caractere, podendo customizar os caracteres.
        /// </summary>
        public static char ToChar(this bool value, char trueChar = '1', char falseChar = '0')
            => value ? trueChar : falseChar;

        /// <summary>
        /// Converte o valor booleano em byte (1 ou 0).
        /// </summary>
        public static byte ToByte(this bool value) => (byte)(value ? 1 : 0);

        /// <summary>
        /// Converte o valor booleano em sbyte (1 ou 0).
        /// </summary>
        public static sbyte ToSByte(this bool value) => (sbyte)(value ? 1 : 0);
    }
}