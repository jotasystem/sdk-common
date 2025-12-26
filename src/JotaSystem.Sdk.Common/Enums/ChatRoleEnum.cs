using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum ChatRoleEnum
    {
        [Display(Name = "Você")]
        User = 1,
        [Display(Name = "Assistente de IA")]
        Assistant = 2,
        [Display(Name = "Sistema")]
        System = 3
    }
}