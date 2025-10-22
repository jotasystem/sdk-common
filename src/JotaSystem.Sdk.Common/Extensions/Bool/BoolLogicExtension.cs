namespace JotaSystem.Sdk.Common.Extensions.Bool
{
    /// <summary>
    /// Extensões para operações lógicas com valores booleanos.
    /// </summary>
    public static class BoolLogicExtension
    {
        /// <summary>
        /// Retorna o resultado lógico de "E" (AND) entre dois valores.
        /// </summary>
        public static bool And(this bool value, bool other) => value && other;

        /// <summary>
        /// Retorna o resultado lógico de "OU" (OR) entre dois valores.
        /// </summary>
        public static bool Or(this bool value, bool other) => value || other;

        /// <summary>
        /// Retorna o resultado lógico de "OU EXCLUSIVO" (XOR) entre dois valores.
        /// </summary>
        public static bool Xor(this bool value, bool other) => value ^ other;

        /// <summary>
        /// Inverte o valor booleano (NOT).
        /// </summary>
        public static bool Not(this bool value) => !value;

        /// <summary>
        /// Inverte o valor booleano (sinônimo de <see cref="Not"/>).
        /// </summary>
        public static bool Toggle(this bool value) => !value;

        /// <summary>
        /// Retorna <c>true</c> se ambos os valores forem iguais.
        /// </summary>
        public static bool IsSameAs(this bool value, bool other) => value == other;

        /// <summary>
        /// Retorna <c>true</c> se os valores forem opostos.
        /// </summary>
        public static bool IsOppositeOf(this bool value, bool other) => value != other;
    }
}
