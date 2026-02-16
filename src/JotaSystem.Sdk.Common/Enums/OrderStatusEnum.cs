using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum OrderStatusEnum
    {
        [Display(Name = "Rascunho")]
        Draft = 0,

        [Display(Name = "Aberto")]
        Open = 1,

        [Display(Name = "Confirmado")]
        Confirmed = 2,

        [Display(Name = "Em Processamento")]
        Processing = 3,

        [Display(Name = "Concluído")]
        Completed = 4,

        [Display(Name = "Cancelado")]
        Canceled = 5,

        [Display(Name = "Expirado")]
        Expired = 6
    }
}