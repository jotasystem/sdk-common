using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum UserTypeEnum
    {
        [Display(Name = "Super Administrador")]
        SuperAdmin = 0,
        [Display(Name = "Administrador")]
        Admin = 1,
        [Display(Name = "Colaborador")]
        Employee = 2,
        [Display(Name = "Cliente")]
        Customer = 3,
        [Display(Name = "Externo")]
        External = 4
    }
}