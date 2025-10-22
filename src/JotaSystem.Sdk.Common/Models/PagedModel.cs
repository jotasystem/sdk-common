using JotaSystem.Sdk.Common.Models.Base;

namespace JotaSystem.Sdk.Common.Models
{
    /// <summary>
    /// Modelo de paginação genérico contendo a lista de resultados
    /// </summary>
    /// <typeparam name="T">Tipo dos itens da página</typeparam>
    public class PagedModel<T> : PagedBase where T : class
    {
        /// <summary>
        /// Resultados da página
        /// </summary>
        public ICollection<T> Results { get; set; }

        /// <summary>
        /// Construtor padrão (Results inicializado vazio)
        /// </summary>
        public PagedModel()
        {
            Results = [];
        }

        /// <summary>
        /// Construtor com inicialização completa
        /// </summary>
        /// <param name="results">Itens da página</param>
        /// <param name="totalItems">Total de itens disponíveis</param>
        /// <param name="currentPage">Página atual</param>
        /// <param name="pageSize">Número de itens por página</param>
        public PagedModel(IEnumerable<T> results, int totalItems, int currentPage = 1, int pageSize = 10)
        {
            Results = results?.ToList() ?? [];
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }

        /// <summary>
        /// Atualiza os resultados e total de itens de forma segura
        /// </summary>
        public void SetPage(IEnumerable<T> results, int totalItems, int currentPage = 1, int pageSize = 10)
        {
            Results = results?.ToList() ?? [];
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }
    }
}