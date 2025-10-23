using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum PersonTypeEnum
    {
        [Display(Name = "Pessoa Física")]
        Individual = 1,
        [Display(Name = "Pessoa Jurídica")]
        LegalEntity = 2,
        [Display(Name = "Pessoa Estrangeira")]
        Foreigner = 3
    }
}