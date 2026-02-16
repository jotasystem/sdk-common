using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum StockReservationEnum
    {
        [Display(Name = "Ativo")]
        Active = 1,
        [Display(Name = "Liberado")]
        Released = 2,
        [Display(Name = "Consumido")]
        Consumed = 3
    }
}