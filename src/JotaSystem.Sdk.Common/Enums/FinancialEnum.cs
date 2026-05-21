using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum FinancialTypeEnum
    {
        [Display(Name = "A pagar")]
        Payable = 1,
        [Display(Name = "A receber")]
        Receivable = 2
    }

    public enum FinancialStatusEnum
    {
        [Display(Name = "Em aberto")]
        Open = 1,
        [Display(Name = "Parcialmente liquidado")]
        PartiallySettled = 2,
        [Display(Name = "Liquidado")]
        Settled = 3,
        [Display(Name = "Vencido")]
        Overdue = 4,
        [Display(Name = "Cancelado")]
        Cancelled = 5
    }

    public enum FinancialPartyEnum
    {
        [Display(Name = "Fornecedor")]
        Supplier = 1,

        [Display(Name = "Cliente")]
        Customer = 2,

        [Display(Name = "Colaborador")]
        Employee = 3,

        [Display(Name = "Outro")]
        Other = 4
    }
    public enum FinancialModeEnum
    {
        [Display(Name = "Lançamento único")]
        Single = 1,

        [Display(Name = "Lançamentos múltiplos")]
        Batch = 2
    }


    public enum FinancialOriginEnum
    {
        [Display(Name = "Manual")]
        Manual = 1,
        [Display(Name = "Pedido de Venda")]
        SalesOrder = 2,
        [Display(Name = "Ordem de Compra")]
        PurchaseOrder = 3,
        [Display(Name = "Ordem de Serviço")]
        ServiceOrder = 4,
        [Display(Name = "Transferência entre contas")]
        Transfer = 5,
        [Display(Name = "Ajuste financeiro")]
        Adjustment = 6,
        [Display(Name = "Sistemas terceiros")]
        Integration = 7
    }
}