namespace JotaSystem.Sdk.Common.Extensions.Task
{
    /// <summary>
    /// Extensões simples de retry para operações assíncronas.
    /// </summary>
    public static class TaskRetryExtension
    {
        /// <summary>
        /// Executa a função assíncrona com uma política de retry simples.
        /// </summary>
        /// <param name="action">Função assíncrona a ser executada.</param>
        /// <param name="attempts">Número total de tentativas (>= 1).</param>
        /// <param name="delayProvider">Função que fornece o delay entre tentativas (recebe número da tentativa, começando em 1).</param>
        public static async System.Threading.Tasks.Task RetryAsync(Func<System.Threading.Tasks.Task> action, int attempts = 3, Func<int, TimeSpan>? delayProvider = null)
        {
            if (action is null) throw new ArgumentNullException(nameof(action));
            if (attempts < 1) throw new ArgumentOutOfRangeException(nameof(attempts));

            var lastException = (System.Exception?)null;
            for (int i = 1; i <= attempts; i++)
            {
                try
                {
                    await action().ConfigureAwait(false);
                    return;
                }
                catch (System.Exception ex)
                {
                    lastException = ex;
                    if (i == attempts) break;
                    var delay = delayProvider?.Invoke(i) ?? TimeSpan.FromMilliseconds(200 * i);
                    await System.Threading.Tasks.Task.Delay(delay).ConfigureAwait(false);
                }
            }
            throw lastException!;
        }

        /// <summary>
        /// Versão genérica que retorna o resultado da operação.
        /// </summary>
        public static async Task<T> RetryAsync<T>(Func<Task<T>> action, int attempts = 3, Func<int, TimeSpan>? delayProvider = null)
        {
            if (action is null) throw new ArgumentNullException(nameof(action));
            if (attempts < 1) throw new ArgumentOutOfRangeException(nameof(attempts));

            System.Exception? lastException = null;
            for (int i = 1; i <= attempts; i++)
            {
                try
                {
                    return await action().ConfigureAwait(false);
                }
                catch (System.Exception ex)
                {
                    lastException = ex;
                    if (i == attempts) break;
                    var delay = delayProvider?.Invoke(i) ?? TimeSpan.FromMilliseconds(200 * i);
                    await System.Threading.Tasks.Task.Delay(delay).ConfigureAwait(false);
                }
            }
            throw lastException!;
        }
    }
}