using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum FinancialOriginEnum
    {
        [Display(Name = "Manual")]
        Manual = 1,
        [Display(Name = "Pedido de Venda")]
        SalesOrder = 2,
        [Display(Name = "Ordem de Compra")]
        PurchaseOrder = 3,
        [Display(Name = "Ordem de Serviço")]
        ServiceOrder = 4
    }
}