namespace JotaSystem.Sdk.Common.Extensions.Exception
{
    /// <summary>
    /// Métodos de extensão para obter inner exceptions.
    /// </summary>
    public static class ExceptionUnwrapExtension
    {
        /// <summary>
        /// Retorna a exception mais interna (innermost exception).
        /// </summary>
        public static System.Exception GetInnermostException(this System.Exception ex)
        {
            if (ex == null) throw new ArgumentNullException(nameof(ex));

            var current = ex;
            while (current.InnerException != null)
            {
                current = current.InnerException;
            }
            return current;
        }
    }
}