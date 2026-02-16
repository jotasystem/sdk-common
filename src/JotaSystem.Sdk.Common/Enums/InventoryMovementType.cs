using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum InventoryMovementType
    {
        [Display(Name = "Entrada")]
        In = 1,
        [Display(Name = "Saída")]
        Out = 2
    }
}