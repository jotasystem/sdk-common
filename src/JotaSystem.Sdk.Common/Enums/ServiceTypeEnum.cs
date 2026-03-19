using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum ServiceTypeEnum
    {
        [Display(Name = "Serviço Simples")]
        Simple = 1,
        [Display(Name = "Pacote de Serviços")]
        Package = 2
    }
}