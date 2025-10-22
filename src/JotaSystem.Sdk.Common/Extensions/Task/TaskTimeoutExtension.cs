namespace JotaSystem.Sdk.Common.Extensions.Task
{
    /// <summary>
    /// Fornece métodos de extensão para controle de timeout em tarefas assíncronas.
    /// </summary>
    public static class TaskTimeoutExtension
    {
        /// <summary>
        /// Aguarda uma tarefa por um período determinado, lançando exceção em caso de estouro.
        /// </summary>
        public static async System.Threading.Tasks.Task WithTimeout(this System.Threading.Tasks.Task task, TimeSpan timeout)
        {
            if (task is null) throw new ArgumentNullException(nameof(task));
            using var cts = new CancellationTokenSource();
            var delayTask = System.Threading.Tasks.Task.Delay(timeout, cts.Token);
            var completed = await System.Threading.Tasks.Task.WhenAny(task, delayTask).ConfigureAwait(false);
            if (completed == task)
            {
                cts.Cancel();
                await task.ConfigureAwait(false);
                return;
            }
            throw new TimeoutException($"A operação excedeu o tempo limite de {timeout.TotalSeconds} segundos.");
        }

        /// <summary>
        /// Aguarda uma tarefa e retorna valor padrão em caso de timeout.
        /// </summary>
        public static async Task<T?> WithTimeoutOrDefault<T>(this Task<T> task, TimeSpan timeout, T? defaultValue = default)
        {
            if (task is null) throw new ArgumentNullException(nameof(task));
            using var cts = new CancellationTokenSource();
            var delayTask = System.Threading.Tasks.Task.Delay(timeout, cts.Token);
            var completed = await System.Threading.Tasks.Task.WhenAny(task, delayTask).ConfigureAwait(false);
            if (completed == task)
            {
                cts.Cancel();
                return await task.ConfigureAwait(false);
            }
            return defaultValue;
        }
    }
}