using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum CompanyTypeEnum
    {
        [Display(Name = "Matriz")]
        Headquarters = 1,
        [Display(Name = "Filial")]
        Branch = 2
    }
}