using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum PaymentStatusEnum
    {
        [Display(Name = "Pendente")]
        Pending = 1,

        [Display(Name = "Parcialmente Pago")]
        PartiallyPaid = 2,

        [Display(Name = "Pago")]
        Paid = 3,

        [Display(Name = "Estornado")]
        Refunded = 4,

        [Display(Name = "Cancelado")]
        Cancelled = 5
    }
}