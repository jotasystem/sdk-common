using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    /// <summary>
    /// Representa o estado atual de uma entidade do sistema.
    /// </summary>
    public enum EntityStatusEnum
    {
        /// <summary>
        /// Entidade criada mas ainda não publicada ou aprovada.
        /// </summary>
        [Display(Name = "Rascunho")]
        Draft = 0,

        /// <summary>
        /// Entidade ativa e disponível para uso no sistema.
        /// </summary>
        [Display(Name = "Ativo")]
        Active = 1,

        /// <summary>
        /// Entidade inativa, não disponível para operações normais.
        /// </summary>
        [Display(Name = "Inativo")]
        Inactive = 2,

        /// <summary>
        /// Entidade arquivada, mantida apenas para histórico.
        /// </summary>
        [Display(Name = "Arquivado")]
        Archived = 3,

        /// <summary>
        /// Entidade aguardando aprovação antes de se tornar ativa.
        /// </summary>
        [Display(Name = "Aprovação pendente")]
        PendingApproval = 4
    }
}