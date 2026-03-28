using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum AuthorizationMode
    {
        [Display(Name = "Nenhum")]
        None = 0,
        [Display(Name = "Permissão")]
        Permission = 1,
        [Display(Name = "Somente Administrador")]
        AdminOnly = 2
    }
}