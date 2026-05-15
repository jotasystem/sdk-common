using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum FinancialPartyTypeEnum
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
}