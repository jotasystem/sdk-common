using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum PaymentStatusEnum
    {
        [Display(Name = "Não Iniciado")]
        NotStarted = 1,

        [Display(Name = "Pendente")]
        Pending = 1,

        [Display(Name = "Autorizado")]
        Authorized = 2,

        [Display(Name = "Pago")]
        Paid = 3,

        [Display(Name = "Pago Parcialmente")]
        PartiallyPaid = 4,

        [Display(Name = "Recusado")]
        Refused = 5,

        [Display(Name = "Cancelado")]
        Canceled = 6,

        [Display(Name = "Estornado")]
        Refunded = 7,

        [Display(Name = "Estornado Parcialmente")]
        PartiallyRefunded = 8
    }
}
