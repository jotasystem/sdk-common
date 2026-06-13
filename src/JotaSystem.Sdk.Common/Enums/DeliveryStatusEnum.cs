using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum FulfillmentStatusEnum
    {
        [Display(Name = "Pendente")]
        Pending = 1,

        [Display(Name = "Em andamento")]
        InProgress = 2,

        [Display(Name = "Concluído")]
        Completed = 3,

        [Display(Name = "Cancelado")]
        Cancelled = 4
    }
}
