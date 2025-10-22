namespace JotaSystem.Sdk.Common.Extensions.Task
{
    /// <summary>
    /// Extensões para suportar cancelamento de tarefas de forma segura.
    /// </summary>
    public static class TaskCancellationExtension
    {
        /// <summary>
        /// Permite aguardar uma task comum com um CancellationToken externo.
        /// Se o token for cancelado, lança OperationCanceledException.
        /// </summary>
        public static async System.Threading.Tasks.Task WithCancellation(this System.Threading.Tasks.Task task, CancellationToken cancellationToken)
        {
            if (task is null) throw new ArgumentNullException(nameof(task));
            var tcs = new TaskCompletionSource<object?>(TaskCreationOptions.RunContinuationsAsynchronously);
            using (cancellationToken.Register(s => ((TaskCompletionSource<object?>)s!).TrySetResult(null), tcs))
            {
                var completed = await System.Threading.Tasks.Task.WhenAny(task, tcs.Task).ConfigureAwait(false);
                if (completed == tcs.Task)
                    throw new OperationCanceledException(cancellationToken);
                await task.ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Versão genérica que apoia CancellationToken e retorna valor.
        /// </summary>
        public static async Task<T> WithCancellation<T>(this Task<T> task, CancellationToken cancellationToken)
        {
            if (task is null) throw new ArgumentNullException(nameof(task));
            var tcs = new TaskCompletionSource<object?>(TaskCreationOptions.RunContinuationsAsynchronously);
            using (cancellationToken.Register(s => ((TaskCompletionSource<object?>)s!).TrySetResult(null), tcs))
            {
                var completed = await System.Threading.Tasks.Task.WhenAny(task, tcs.Task).ConfigureAwait(false);
                if (completed == tcs.Task)
                    throw new OperationCanceledException(cancellationToken);
                return await task.ConfigureAwait(false);
            }
        }
    }
}