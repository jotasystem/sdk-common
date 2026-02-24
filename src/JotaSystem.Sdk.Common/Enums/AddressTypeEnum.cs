using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum AddressTypeEnum
    {
        [Display(Name = "Residencial")]
        Home = 1,
        [Display(Name = "Comercial")]
        Business = 2,
        [Display(Name = "Entrega")]
        Shipping = 3,
        [Display(Name = "Cobrança")]
        Billing = 4,
        [Display(Name = "Outro")]
        Other = 5
    }
}