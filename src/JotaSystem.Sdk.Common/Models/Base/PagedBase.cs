namespace JotaSystem.Sdk.Common.Models.Base
{
    /// <summary>
    /// Modelo base para paginação, contendo informações de total de itens e páginas.
    /// </summary>
    public abstract class PagedBase
    {
        /// <summary>
        /// Página atual (1-based)
        /// </summary>
        public int CurrentPage { get; set; } = 1;

        /// <summary>
        /// Número de itens por página
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Total de itens disponíveis
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Total de páginas
        /// </summary>
        public int TotalPages => PageSize == 0 ? 0 : (int)Math.Ceiling(TotalItems / (double)PageSize);

        /// <summary>
        /// Índice da primeira linha desta página (1-based)
        /// </summary>
        public int FirstRowOnPage => Math.Max(1, (CurrentPage - 1) * PageSize + 1);

        /// <summary>
        /// Índice da última linha desta página
        /// </summary>
        public int LastRowOnPage => Math.Min(CurrentPage * PageSize, TotalItems);

        /// <summary>
        /// Indica se há página seguinte
        /// </summary>
        public bool HasNextPage => CurrentPage < TotalPages;

        /// <summary>
        /// Indica se há página anterior
        /// </summary>
        public bool HasPreviousPage => CurrentPage > 1;
    }
}