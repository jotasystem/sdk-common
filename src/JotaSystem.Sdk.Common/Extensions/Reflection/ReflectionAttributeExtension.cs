using System.Reflection;

namespace JotaSystem.Sdk.Common.Extensions.Reflection
{
    /// <summary>
    /// Extensões para manipulação de atributos de classes e propriedades.
    /// </summary>
    public static class ReflectionAttributeExtension
    {
        /// <summary>
        /// Verifica se o membro possui o atributo TAttribute.
        /// </summary>
        public static bool HasAttribute<TAttribute>(this MemberInfo member) where TAttribute : Attribute
            => member.GetCustomAttributes(typeof(TAttribute), true).Any();

        /// <summary>
        /// Obtém a primeira instância do atributo TAttribute do membro, ou null.
        /// </summary>
        public static TAttribute? GetAttribute<TAttribute>(this MemberInfo member) where TAttribute : Attribute
            => member.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;

        /// <summary>
        /// Obtém todos os atributos do tipo TAttribute do membro.
        /// </summary>
        public static TAttribute[] GetAttributes<TAttribute>(this MemberInfo member) where TAttribute : Attribute
            => member.GetCustomAttributes(typeof(TAttribute), true).Cast<TAttribute>().ToArray();
    }
}