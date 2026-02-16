using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum ReservationStatus
    {
        [Display(Name = "Ativo")]
        Active = 1,
        [Display(Name = "Lançado")]
        Released = 2,
        [Display(Name = "Consumido")]
        Consumed = 3
    }
}