using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Common.Enums
{
    public enum OrderTypeEnum
    {
        [Display(Name = "Orçamento")]
        Estimate = 0,
        [Display(Name = "Pedido de Venda")]
        SalesOrder = 1,
        [Display(Name = "Serviço de Venda")]
        SalesService = 2
    }

    public enum OrderStatusEnum
    {
        [Display(Name = "Rascunho")]
        Draft = 0,

        [Display(Name = "Aberto")]
        Open = 1,

        [Display(Name = "Pendente")]
        Pending = 2,

        [Display(Name = "Confirmado")]
        Confirmed = 3,

        [Display(Name = "Em Processamento")]
        InProgress = 4,

        [Display(Name = "Concluído")]
        Completed = 5,

        [Display(Name = "Cancelado")]
        Cancelled = 6,

        [Display(Name = "Expirado")]
        Expired = 7
    }

    public enum OrderSalesChannelEnum
    {
        [Display(Name = "Loja física / PDV")]
        InStore = 1,

        [Display(Name = "E-commerce")]
        Ecommerce = 2,

        [Display(Name = "Marketplace")]
        Marketplace = 3,

        [Display(Name = "WhatsApp")]
        WhatsApp = 4,

        [Display(Name = "Redes sociais")]
        SocialMedia = 5,

        [Display(Name = "Telefone")]
        Telephone = 6,

        [Display(Name = "Venda externa / representante")]
        FieldSales = 7,

        [Display(Name = "Integração / API")]
        Integration = 8,

        [Display(Name = "Outros")]
        Other = 99
    }

    public enum OrderSalesOriginEnum
    {
        [Display(Name = "Busca orgânica")]
        OrganicSearch = 1,

        [Display(Name = "Indicação")]
        Referral = 2,

        [Display(Name = "Tráfego pago")]
        PaidTraffic = 3,

        [Display(Name = "Campanha promocional")]
        Campaign = 4,

        [Display(Name = "Prospecção ativa")]
        OutboundProspecting = 5,

        [Display(Name = "Cliente recorrente")]
        ReturningCustomer = 6,

        [Display(Name = "Parceiro")]
        Partner = 7,

        [Display(Name = "Evento / feira")]
        Event = 8,

        [Display(Name = "Outros")]
        Other = 99
    }
}