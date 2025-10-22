using System.Reflection;

namespace JotaSystem.Sdk.Common.Extensions.Reflection
{
    /// <summary>
    /// Extensões para invocação dinâmica de métodos.
    /// </summary>
    public static class ReflectionMethodExtension
    {
        /// <summary>
        /// Invoca um método público pelo nome com argumentos.
        /// </summary>
        /// <param name="obj">Objeto alvo.</param>
        /// <param name="methodName">Nome do método.</param>
        /// <param name="args">Argumentos para o método.</param>
        /// <returns>Resultado do método ou null.</returns>
        public static object? InvokeMethod(this object obj, string methodName, params object?[] args)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(methodName)) throw new ArgumentNullException(nameof(methodName));

            var method = obj.GetType().GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance);
            if (method == null) throw new ArgumentException($"Method '{methodName}' not found.");

            return method.Invoke(obj, args);
        }

        /// <summary>
        /// Tenta invocar um método e retorna default caso ocorra exceção ou resultado incompatível.
        /// </summary>
        /// <typeparam name="T">Tipo esperado do resultado.</typeparam>
        /// <param name="obj">Objeto alvo.</param>
        /// <param name="methodName">Nome do método.</param>
        /// <param name="args">Argumentos do método.</param>
        /// <returns>Resultado convertido ou default.</returns>
        public static T? TryInvokeMethod<T>(this object obj, string methodName, params object?[] args)
        {
            try
            {
                var result = obj.InvokeMethod(methodName, args);
                return result is T t ? t : default;
            }
            catch
            {
                return default;
            }
        }
    }
}