using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum FinancialStatusEnum
    {
        [Display(Name = "Pendente")]
        Pending = 1,
        [Display(Name = "Parcialmente pago")]
        PartiallyPaid = 2,
        [Display(Name = "Pago")]
        Paid = 3,
        [Display(Name = "Cancelado")]
        Cancelled = 4
    }
}
