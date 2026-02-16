using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum InventoryMovementReason
    {
        [Display(Name = "Compra")]
        Purchase = 1,
        [Display(Name = "Venda")]
        Sale = 2,
        [Display(Name = "Devolução de Entrada")]
        ReturnIn = 3,
        [Display(Name = "Devolução de Saída")]
        ReturnOut = 4,
        [Display(Name = "Transferência de Entrada")]
        TransferIn = 5,
        [Display(Name = "Transferência de Saída")]
        TransferOut = 6,
        [Display(Name = "Ajuste")]
        Adjustment = 7,
        [Display(Name = "Reserva Consumida")]
        ReservationConsumed = 8
    }
}