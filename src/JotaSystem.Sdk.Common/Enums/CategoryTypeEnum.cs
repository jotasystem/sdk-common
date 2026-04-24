using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum CategoryTypeEnum
    {
        [Display(Name = "Produto")]
        Product = 1,
        [Display(Name = "Serviço")]
        Service = 2
    }
}