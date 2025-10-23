using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum BusinessModelEnum
    {
        [Display(Name = "Matriz")]
        Parent = 1,
        [Display(Name = "Filial")]
        Branch = 2,
        [Display(Name = "Franquia")]
        Franchise = 3,
        [Display(Name = "Rede")]
        Network = 4
    }
}