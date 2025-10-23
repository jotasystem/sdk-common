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
}