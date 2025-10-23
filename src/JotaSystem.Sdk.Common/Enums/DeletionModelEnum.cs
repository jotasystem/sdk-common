using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum DeletionModelEnum
    {
        [Display(Name = "Exclusão Física")]
        Physical = 1,
        [Display(Name = "Exclusão Lógica")]
        Logical = 2
    }
}