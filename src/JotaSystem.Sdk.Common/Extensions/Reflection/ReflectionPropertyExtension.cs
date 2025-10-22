using System.Reflection;

namespace JotaSystem.Sdk.Common.Extensions.Reflection
{
    /// <summary>
    /// Extensões para leitura e escrita dinâmica de propriedades.
    /// </summary>
    public static class ReflectionPropertyExtension
    {
        /// <summary>
        /// Obtém o valor de uma propriedade pelo nome.
        /// </summary>
        /// <param name="obj">Objeto alvo.</param>
        /// <param name="propertyName">Nome da propriedade.</param>
        /// <returns>Valor da propriedade ou null.</returns>
        public static object? GetPropertyValue(this object obj, string propertyName)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(propertyName)) throw new ArgumentNullException(nameof(propertyName));

            var prop = obj.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            return prop?.GetValue(obj);
        }

        /// <summary>
        /// Define o valor de uma propriedade pelo nome.
        /// </summary>
        /// <param name="obj">Objeto alvo.</param>
        /// <param name="propertyName">Nome da propriedade.</param>
        /// <param name="value">Valor a ser definido.</param>
        public static void SetPropertyValue(this object obj, string propertyName, object? value)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(propertyName)) throw new ArgumentNullException(nameof(propertyName));

            var prop = obj.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            if (prop == null) throw new ArgumentException($"Property '{propertyName}' not found.");

            prop.SetValue(obj, value);
        }

        /// <summary>
        /// Tenta obter o valor de uma propriedade e retorna default caso não exista ou seja incompatível.
        /// </summary>
        /// <typeparam name="T">Tipo esperado do valor.</typeparam>
        /// <param name="obj">Objeto alvo.</param>
        /// <param name="propertyName">Nome da propriedade.</param>
        /// <returns>Valor convertido ou default.</returns>
        public static T? TryGetPropertyValue<T>(this object obj, string propertyName)
        {
            var value = obj.GetPropertyValue(propertyName);
            return value is T tValue ? tValue : default;
        }
    }
}