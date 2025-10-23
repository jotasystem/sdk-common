using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum GenderPersonEnum
    {
        [Display(Name = "Não informar")]
        NotInform = 0,
        [Display(Name = "Masculino")]
        Masculine = 1,
        [Display(Name = "Feminino")]
        Feminine = 2
    }
}