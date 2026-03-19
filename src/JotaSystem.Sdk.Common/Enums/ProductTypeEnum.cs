using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum ProductTypeEnum
    {
        [Display(Name = "Produto Simples")]
        Simple = 1,
        [Display(Name = "Produto Variável")]
        Variable = 2,
        [Display(Name = "Produto Composto")]
        Composite = 3
    }
}
