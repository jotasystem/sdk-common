using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum AccountTypeEnum
    {
        [Display(Name = "Poupança")]
        Savings = 1,
        [Display(Name = "Corrente")]
        Current = 2
    }
}