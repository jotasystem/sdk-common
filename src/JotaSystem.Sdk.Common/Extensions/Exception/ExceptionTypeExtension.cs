namespace JotaSystem.Sdk.Common.Extensions.Exception
{
    /// <summary>
    /// Métodos de extensão para inspeção de tipos de exceção.
    /// </summary>
    public static class ExceptionTypeExtension
    {
        /// <summary>
        /// Retorna true se a exception ou qualquer inner exception for do tipo T.
        /// </summary>
        public static bool IsOfType<T>(this System.Exception ex) where T : System.Exception
        {
            if (ex == null) throw new ArgumentNullException(nameof(ex));
            var current = ex;
            while (current != null)
            {
                if (current is T) return true;
                current = current.InnerException;
            }
            return false;
        }

        /// <summary>
        /// Retorna true se a exception for TimeoutException ou derivada.
        /// </summary>
        public static bool IsTimeout(this System.Exception ex)
            => ex.IsOfType<TimeoutException>();
    }
}