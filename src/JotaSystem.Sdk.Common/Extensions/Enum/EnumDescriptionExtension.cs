using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace JotaSystem.Sdk.Common.Extensions.Enum
{
    /// <summary>
    /// Extensões para obter informações de descrição e nome de enums.
    /// </summary>
    public static class EnumDescriptionExtension
    {
        /// <summary>
        /// Retorna o nome amigável definido pelo atributo <see cref="DisplayAttribute"/> associado ao valor do enum.
        /// Caso o atributo não esteja presente, tenta retornar a descrição definida em <see cref="DescriptionAttribute"/>.
        /// Se nenhum atributo existir, retorna o nome do enum.
        /// </summary>
        /// <param name="value">Valor do enum.</param>
        /// <returns>Nome definido em <see cref="DisplayAttribute"/>, descrição ou o nome do enum.</returns>
        public static string GetDisplayName(this System.Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field == null) return value.ToString();

            // DisplayAttribute
            var displayAttribute = field.GetCustomAttribute<DisplayAttribute>();
            if (displayAttribute != null && !string.IsNullOrWhiteSpace(displayAttribute.Name))
                return displayAttribute.Name;

            // DescriptionAttribute como fallback
            var descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>();
            if (descriptionAttribute != null)
                return descriptionAttribute.Description;

            // Nome do enum como último recurso
            return value.ToString();
        }

        /// <summary>
        /// Retorna a descrição associada ao valor do enum, definida pelo atributo <see cref="DescriptionAttribute"/>.
        /// Caso o atributo não esteja presente, retorna o nome do enum.
        /// </summary>
        /// <param name="value">Valor do enum.</param>
        /// <returns>Descrição definida ou o nome do enum.</returns>
        public static string GetDescription(this System.Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field == null) return value.ToString();

            var attribute = (DescriptionAttribute?)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute?.Description ?? value.ToString();
        }

        /// <summary>
        /// Retorna o nome textual do valor do enum.
        /// </summary>
        /// <param name="value">Valor do enum.</param>
        /// <returns>Nome do valor do enum.</returns>
        public static string GetName(this System.Enum value) =>
            System.Enum.GetName(value.GetType(), value) ?? string.Empty;
    }
}