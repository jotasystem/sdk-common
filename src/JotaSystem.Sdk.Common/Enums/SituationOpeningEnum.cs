using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum SituationOpeningEnum
    {
        [Display(Name = "Não informar")]
        NotInform = 0,
        [Display(Name = "Em funcionamento")]
        InOperation = 1,
        [Display(Name = "Inauguração em Breve")]
        OpeningSoon = 2,
        [Display(Name = "Distratada")]
        Distracted = 3,
        [Display(Name = "Distrato em Andamento")]
        DistractedInProgress = 4,
        [Display(Name = "Baixa de Bandeira")]
        LowerBandeira = 5,
        [Display(Name = "Loja Repassada")]
        StoreRepassada = 6,
        [Display(Name = "Mudança de Território")]
        TerritoryChange = 7
    }
}