using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum FinancialStatusEnum
    {
        [Display(Name = "Em aberto")]
        Open = 1,
        [Display(Name = "Parcialmente liquidado")]
        PartiallySettled = 2,
        [Display(Name = "Liquidado")]
        Settled = 3,
        [Display(Name = "Vencido")]
        Overdue = 4,
        [Display(Name = "Cancelado")]
        Cancelled = 5
    }
}