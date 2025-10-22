using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JotaSystem.Sdk.Common.Extensions.Object
{
    /// <summary>
    /// Fornece métodos de extensão para inspeção e manipulação de objetos via reflexão.
    /// </summary>
    public static class ObjectReflectionExtension
    {
        /// <summary>
        /// Retorna o valor de uma propriedade pelo nome.
        /// </summary>
        public static object? GetPropertyValue(this object obj, string propertyName)
        {
            var prop = obj.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            return prop?.GetValue(obj);
        }

        /// <summary>
        /// Indica se o objeto possui uma propriedade pública com o nome especificado.
        /// </summary>
        public static bool HasProperty(this object obj, string propertyName)
            => obj.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance) != null;

        /// <summary>
        /// Retorna um dicionário com todas as propriedades públicas e seus respectivos valores.
        /// </summary>
        public static Dictionary<string, object?> GetPropertiesDictionary(this object obj)
            => obj.GetType()
                  .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                  .ToDictionary(p => p.Name, p => p.GetValue(obj));
    }
}