using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum CategoryTypeEnum
    {
        [Display(Name = "Nenhum")]
        None = 0,
        [Display(Name = "Produto")]
        Product = 1,
        [Display(Name = "Serviço")]
        Service = 2
    }
}