using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum BankReconciliationStatusEnum
    {
        [Display(Name = "Pendente")]
        Pending = 1,
        [Display(Name = "Conciliado")]
        Reconciled = 2
    }

    public enum BankTransactionOriginEnum
    {
        [Display(Name = "Manual")]
        Manual = 1,
        [Display(Name = "Liquidação")]
        Settlement = 2,
        [Display(Name = "Importação")]
        Import = 3,
        [Display(Name = "Ajuste")]
        Adjustment = 4
    }

    public enum BankTransactionStatusEnum
    {
        [Display(Name = "Confirmado")]
        Confirmed = 1,
        [Display(Name = "Pendente")]
        Pending = 2,
        [Display(Name = "Cancelado")]
        Cancelled = 3
    }

    public enum BankTransactionTypeEnum
    {
        [Display(Name = "Entrada")]
        Credit = 1,
        [Display(Name = "Saída")]
        Debit = 2
    }
}