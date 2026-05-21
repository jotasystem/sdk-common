using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum PageOrdemEnum
    {
        [Display(Name = "Mais novos")]
        Newest = 1,
        [Display(Name = "Mais antigos")]
        Oldest = 2,
        [Display(Name = "Atualizados recentementes")]
        RecentlyUpdated = 3,
        [Display(Name = "Nome de A - Z")]
        NameAZ = 4,
        [Display(Name = "Nome de Z - A")]
        NameZA = 5
    }

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