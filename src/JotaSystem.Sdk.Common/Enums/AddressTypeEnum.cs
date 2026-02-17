using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum AddressTypeEnum
    {
        [Display(Name = "Cobrança")]
        Billing = 1,

        [Display(Name = "Entrega")]
        Shipping = 2,

        [Display(Name = "Cobrança e Entrega")]
        BillingAndShipping = 3,

        [Display(Name = "Residencial")]
        Residential = 4,

        [Display(Name = "Comercial")]
        Commercial = 5,

        [Display(Name = "Outro")]
        Other = 6
    }
}