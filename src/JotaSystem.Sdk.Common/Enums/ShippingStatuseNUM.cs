using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum ShippingStatusEnum
    {
        [Display(Name = "Não Aplicável")]
        NotApplicable = 0,

        [Display(Name = "Aguardando Processamento")]
        Waiting = 1,

        [Display(Name = "Em Separação")]
        Picking = 2,

        [Display(Name = "Separado")]
        Packed = 3,

        [Display(Name = "Enviado")]
        Shipped = 4,

        [Display(Name = "Enviado Parcialmente")]
        PartiallyShipped = 5,

        [Display(Name = "Entregue")]
        Delivered = 6,

        [Display(Name = "Devolvido")]
        Returned = 7
    }
}