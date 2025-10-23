using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum PageSizeEnum
    {
        [Display(Name = "5")]
        Five = 5,
        [Display(Name = "10")]
        Ten = 10,
        [Display(Name = "25")]
        TwentyFive = 25,
        [Display(Name = "50")]
        Fifty = 50,
        [Display(Name = "100")]
        Hundred = 100
    }
}