using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum OrderTypeEnum
    {
        [Display(Name = "Orçamento")]
        Estimate = 0,
        [Display(Name = "Pedido de Venda")]
        SalesOrder = 1,
        [Display(Name = "Serviço de Venda")]
        SalesService = 2
    }
}