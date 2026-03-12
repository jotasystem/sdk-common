using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum OrderTypeEnum
    {
        [Display(Name = "Orçamento")]
        Estimate = 1,
        [Display(Name = "Pedido de Venda")]
        SalesOrder = 2,
        [Display(Name = "Serviço de Venda")]
        SalesService = 3
    }
}