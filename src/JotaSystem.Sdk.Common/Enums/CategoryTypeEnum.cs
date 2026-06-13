using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum ItemTypeEnum
    {
        [Display(Name = "Produto")]
        Product = 1,
        [Display(Name = "Serviço")]
        Service = 2
    }
}