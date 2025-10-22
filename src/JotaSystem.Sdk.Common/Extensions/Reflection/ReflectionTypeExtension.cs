namespace JotaSystem.Sdk.Common.Extensions.Reflection
{
    /// <summary>
    /// Extensões para inspeção de tipos.
    /// </summary>
    public static class ReflectionTypeExtension
    {
        /// <summary>
        /// Verifica se o tipo é Nullable.
        /// </summary>
        public static bool IsNullableType(this Type type)
            => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);

        /// <summary>
        /// Verifica se o tipo é IEnumerable (exceto string).
        /// </summary>
        public static bool IsEnumerableType(this Type type)
            => typeof(System.Collections.IEnumerable).IsAssignableFrom(type) && type != typeof(string);

        /// <summary>
        /// Verifica se o tipo é um tipo anônimo.
        /// </summary>
        public static bool IsAnonymousType(this Type type)
            => Attribute.IsDefined(type, typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), false)
                && type.IsGenericType && type.Name.Contains("AnonymousType");

        /// <summary>
        /// Retorna o tipo subjacente se Nullable, senão o próprio tipo.
        /// </summary>
        public static Type GetUnderlyingType(this Type type)
            => Nullable.GetUnderlyingType(type) ?? type;
    }
}