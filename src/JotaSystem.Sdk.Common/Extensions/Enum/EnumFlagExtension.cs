namespace JotaSystem.Sdk.Common.Extensions.Enum
{
    /// <summary>
    /// Extensões para manipulação de enums marcados com [Flags].
    /// </summary>
    public static class EnumFlagExtensions
    {
        /// <summary>
        /// Verifica se um enum com flags contém a flag especificada.
        /// </summary>
        /// <param name="value">Enum principal.</param>
        /// <param name="flag">Flag a ser verificada.</param>
        /// <returns>True se contiver a flag, false caso contrário.</returns>
        public static bool HasFlagFast(this System.Enum value, System.Enum flag) =>
            (Convert.ToInt64(value) & Convert.ToInt64(flag)) == Convert.ToInt64(flag);

        /// <summary>
        /// Adiciona uma flag a um enum com flags.
        /// </summary>
        /// <typeparam name="T">Tipo do enum.</typeparam>
        /// <param name="value">Enum principal.</param>
        /// <param name="flag">Flag a ser adicionada.</param>
        /// <returns>Enum resultante com a flag adicionada.</returns>
        public static T AddFlag<T>(this T value, T flag) where T : System.Enum
        {
            var result = Convert.ToInt64(value) | Convert.ToInt64(flag);
            return (T)System.Enum.ToObject(typeof(T), result);
        }

        /// <summary>
        /// Remove uma flag de um enum com flags.
        /// </summary>
        /// <typeparam name="T">Tipo do enum.</typeparam>
        /// <param name="value">Enum principal.</param>
        /// <param name="flag">Flag a ser removida.</param>
        /// <returns>Enum resultante sem a flag especificada.</returns>
        public static T RemoveFlag<T>(this T value, T flag) where T : System.Enum
        {
            var result = Convert.ToInt64(value) & ~Convert.ToInt64(flag);
            return (T)System.Enum.ToObject(typeof(T), result);
        }
    }
}