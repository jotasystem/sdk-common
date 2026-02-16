using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum ProductUnitEnum
    {
        [Display(Name = "UN - Unidade")]
        UN = 0,

        [Display(Name = "KG - Quilograma")]
        KG = 1,

        [Display(Name = "G - Grama")]
        G = 2,

        [Display(Name = "LT - Litro")]
        LT = 3,

        [Display(Name = "ML - Mililitro")]
        ML = 4,

        [Display(Name = "M - Metro")]
        M = 5,

        [Display(Name = "CM - Centímetro")]
        CM = 6,

        [Display(Name = "CX - Caixa")]
        CX = 7,

        [Display(Name = "PCT - Pacote")]
        PCT = 8,

        [Display(Name = "FD - Fardo")]
        FD = 9,

        [Display(Name = "PAR - Par")]
        PAR = 10,

        [Display(Name = "SV - Serviço")]
        SV = 11
    }
}