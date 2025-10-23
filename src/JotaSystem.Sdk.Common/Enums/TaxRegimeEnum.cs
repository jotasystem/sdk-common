using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum TaxRegimeEnum
    {
        [Display(Name = "Não Definido")]
        NotDefined = 0,
        [Display(Name = "Simples Nacional")]
        SimpleNational = 1,
        [Display(Name = "Simples Nacional - Excesso")]
        SimplesNacionalExcess = 2,
        [Display(Name = "Normal - Lucro Presumido/Lucro Real")]
        NormalPresumedProfit = 3,
        [Display(Name = "Normal - Lucro Real")]
        NormalRealProfit = 4
    }
}