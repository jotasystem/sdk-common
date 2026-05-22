using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum AccountPlanNatureEnum
    {
        [Display(Name = "Receita")]
        Revenue = 1,
        [Display(Name = "Custo")]
        Cost = 2,
        [Display(Name = "Despesa")]
        Expense = 3,
        [Display(Name = "Ativo")]
        Asset = 4,
        [Display(Name = "Passivo")]
        Liability = 5,
        [Display(Name = "Patrimônio Líquido")]
        Equity = 6,
        [Display(Name = "Dedução de Receita")]
        RevenueDeduction = 7,
        [Display(Name = "Receita Financeira")]
        FinancialRevenue = 8,
        [Display(Name = "Despesa Financeira")]
        FinancialExpense = 9,
        [Display(Name = "Tributo")]
        Tax = 10
    }
}