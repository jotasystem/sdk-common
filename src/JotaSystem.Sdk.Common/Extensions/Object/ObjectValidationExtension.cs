using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JotaSystem.Sdk.Common.Extensions.Object
{
    /// <summary>
    /// Fornece métodos de extensão para validações genéricas de objetos.
    /// </summary>
    public static class ObjectValidationExtension
    {
        /// <summary>
        /// Lança uma exceção se o objeto for nulo.
        /// </summary>
        public static T ThrowIfNull<T>(this T? obj, string paramName)
        {
            if (obj is null)
                throw new ArgumentNullException(paramName);
            return obj;
        }

        /// <summary>
        /// Lança uma exceção se o objeto for igual ao valor padrão do tipo.
        /// </summary>
        public static T ThrowIfDefault<T>(this T obj, string paramName)
        {
            if (EqualityComparer<T>.Default.Equals(obj, default))
                throw new ArgumentException($"{paramName} não pode ser o valor padrão ({default(T)})", paramName);
            return obj;
        }

        /// <summary>
        /// Lança uma exceção se uma condição for falsa.
        /// </summary>
        public static void Ensure(this bool condition, string message)
        {
            if (!condition)
                throw new InvalidOperationException(message);
        }
    }
}
