using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum PhoneType
    {
        [Display(Name = "Telefone Móvel")]
        Mobile = 1,
        [Display(Name = "Telefone Fixo")]
        Landline = 2
    }
}