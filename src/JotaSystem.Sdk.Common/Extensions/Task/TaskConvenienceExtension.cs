namespace JotaSystem.Sdk.Common.Extensions.Task
{
    /// <summary>
    /// Métodos utilitários para tarefas assíncronas (fire-and-forget, TryAwait etc.).
    /// </summary>
    public static class TaskConvenienceExtension
    {
        /// <summary>
        /// Executa a tarefa sem aguardar o término, suprimindo exceções não tratadas.
        /// Use com cuidado (fire-and-forget).
        /// </summary>
        /// <param name="task">Task a ser executada.</param>
        /// <param name="onException">Callback opcional em caso de exceção.</param>
        public static async void FireAndForget(this System.Threading.Tasks.Task task, Action<System.Exception>? onException = null)
        {
            if (task is null) throw new ArgumentNullException(nameof(task));
            try
            {
                await task.ConfigureAwait(false);
            }
            catch (System.Exception ex)
            {
                try { onException?.Invoke(ex); } catch { /* evitar elevação */ }
            }
        }

        /// <summary>
        /// Aguarda a tarefa e retorna se foi concluída com sucesso (true) ou falhou (false).
        /// Exceções são suprimidas.
        /// </summary>
        public static async Task<bool> TryAwait(this System.Threading.Tasks.Task task)
        {
            if (task is null) throw new ArgumentNullException(nameof(task));
            try
            {
                await task.ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Aguarda a tarefa e retorna um valor padrão em caso de exceção.
        /// </summary>
        /// <typeparam name="T">Tipo do resultado.</typeparam>
        public static async Task<T?> TryAwait<T>(this Task<T> task, T? defaultValue = default)
        {
            if (task is null) throw new ArgumentNullException(nameof(task));
            try
            {
                return await task.ConfigureAwait(false);
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}