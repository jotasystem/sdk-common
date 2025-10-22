using System.Text;

namespace JotaSystem.Sdk.Common.Extensions.Exception
{
    /// <summary>
    /// Métodos de extensão para formatação de exceções.
    /// </summary>
    public static class ExceptionFormattingExtension
    {
        /// <summary>
        /// Retorna uma string com a mensagem completa e stacktrace, incluindo inner exceptions.
        /// </summary>
        public static string ToFullString(this System.Exception ex)
        {
            if (ex == null) throw new ArgumentNullException(nameof(ex));

            var sb = new StringBuilder();
            var current = ex;
            int level = 0;

            while (current != null)
            {
                sb.AppendLine($"[{level}] {current.GetType().FullName}: {current.Message}");
                sb.AppendLine(current.StackTrace ?? string.Empty);
                current = current.InnerException;
                level++;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Retorna apenas a mensagem concatenada de todas as inner exceptions.
        /// </summary>
        public static string ToAllMessages(this System.Exception ex)
        {
            if (ex == null) throw new ArgumentNullException(nameof(ex));

            var sb = new StringBuilder();
            var current = ex;

            while (current != null)
            {
                if (sb.Length > 0) sb.Append(" --> ");
                sb.Append(current.Message);
                current = current.InnerException;
            }

            return sb.ToString();
        }
    }
}
