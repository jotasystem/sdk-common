using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum AccountPlanNatureEnum
    {
        [Display(Name = "Receita Financeira")]
        Revenue = 1,
        [Display(Name = "Despesa Financeira")]
        Expense = 2,
        [Display(Name = "Deduções de Receita")]
        RevenueDeduction = 3,
        [Display(Name = "Impostos e Taxas")]
        Tax = 4
    }
}