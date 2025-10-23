using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum PermissionType
    {
        [Display(Name = "Criar")]
        Create = 1,
        [Display(Name = "Editar")]
        Edit = 2,
        [Display(Name = "Excluir")]
        Delete = 3,
        [Display(Name = "Exportar")]
        Export = 4,
        [Display(Name = "Importar")]
        Import = 5
    }
}