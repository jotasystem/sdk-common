using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum UserProfileEnum
    {
        [Display(Name = "Externo")]
        External = 0,
        [Display(Name = "Administrador")]
        Administrator = 1,
        [Display(Name = "Colaborador")]
        Collaborator = 2,
        [Display(Name = "Parceiro")]
        Partner = 3,
        [Display(Name = "Cliente")]
        Customer = 4
    }
}