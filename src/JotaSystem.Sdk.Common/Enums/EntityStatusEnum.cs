using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum EntityStatusEnum
    {
        [Display(Name = "Rascunho")]
        Draft = 0,
        [Display(Name = "Ativo")]
        Active = 1,
        [Display(Name = "Inativo")]
        Inactive = 2,
        [Display(Name = "Arquivado")]
        Archived = 3,
        [Display(Name = "Aprovação pendente")]
        PendingApproval = 4
    }
}