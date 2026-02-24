using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum PersonTypeEnum
    {
        [Display(Name = "Indivíduo - PF")]
        Individual = 1,
        [Display(Name = "Organização - PJ")]
        Organization = 2
    }
}