using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum StockReasonEnum
    {
        [Display(Name = "Compra")]
        Purchase = 1,
        [Display(Name = "Venda")]
        Sale = 2,
        [Display(Name = "Devolução")]
        Return = 3,
        [Display(Name = "Transferência")]
        Transfer = 4,
        [Display(Name = "Ajuste")]
        Adjustment = 5,
        [Display(Name = "Reserva")]
        Reservation = 6
    }
}