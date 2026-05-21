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

    public enum OrderStatusEnum
    {
        [Display(Name = "Rascunho")]
        Draft = 0,

        [Display(Name = "Aberto")]
        Open = 1,

        [Display(Name = "Pendente")]
        Pending = 2,

        [Display(Name = "Confirmado")]
        Confirmed = 3,

        [Display(Name = "Em Processamento")]
        InProgress = 4,

        [Display(Name = "Concluído")]
        Completed = 5,

        [Display(Name = "Cancelado")]
        Cancelled = 6,

        [Display(Name = "Expirado")]
        Expired = 7
    }
}