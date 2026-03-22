using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum BusinessModelEnum
    {
        [Display(Name = "Próprio")]
        Own = 1,
        [Display(Name = "Franquia")]
        Franchise = 2,
        [Display(Name = "Rede")]
        Network = 3
    }
}