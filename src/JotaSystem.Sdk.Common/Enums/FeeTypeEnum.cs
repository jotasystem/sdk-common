using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum FeeTypeEnum
    {
        [Display(Name = "Alíquota (%)")]
        Aliquot = 1,
        [Display(Name = "Fixa (R$)")]
        Fixed = 2
    }
}
