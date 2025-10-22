using JotaSystem.Sdk.Common.Extensions.Task;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Task
{
    public class TaskCancellationExtensionTest
    {
        [Fact]
        public async System.Threading.Tasks.Task WithCancellation_ShouldThrow_WhenTokenCanceled()
        {
            using var cts = new CancellationTokenSource();
            var task = System.Threading.Tasks.Task.Delay(500);
            cts.CancelAfter(20);
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await task.WithCancellation(cts.Token));
        }


        [Fact]
        public async System.Threading.Tasks.Task WithCancellation_Generic_ShouldReturnValue_WhenNotCanceled()
        {
            using var cts = new CancellationTokenSource();
            var task = System.Threading.Tasks.Task.FromResult(123);
            var result = await task.WithCancellation(cts.Token);
            Assert.Equal(123, result);
        }
    }
}