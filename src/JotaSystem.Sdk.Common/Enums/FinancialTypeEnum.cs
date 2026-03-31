using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum FinancialTypeEnum
    {
        [Display(Name = "A pagar")]
        Payable = 1,
        [Display(Name = "A receber")]
        Receivable = 2
    }
}