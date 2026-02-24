using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum DocumentTypeEnum
    {
        [Display(Name = "CPF")]
        CPF = 1,
        [Display(Name = "CNPJ")]
        CNPJ = 2,
        [Display(Name = "Passaporte")]
        Passport = 3,
        [Display(Name = "NIF")]
        ForeignTaxId = 4
    }
}