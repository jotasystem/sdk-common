using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum AccessScopeEnum
    {
        [Display(Name = "Qualquer")]
        Any = 1,
        [Display(Name = "Somente sede")]
        HeadquartersOnly = 2,
        [Display(Name = "Somente filial")]
        BranchOnly = 3
    }
}