using JotaSystem.Sdk.Common.Extensions.Task;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Task
{
    public class TaskRetryExtensionTest
    {
        [Fact]
        public async System.Threading.Tasks.Task RetryAsync_ShouldSucceed_AfterRetries()
        {
            var attempt = 0;
            await TaskRetryExtension.RetryAsync(async () =>
            {
                attempt++;
                if (attempt < 3) throw new InvalidOperationException("fail");
                await System.Threading.Tasks.Task.CompletedTask;
            }, attempts: 5);


            Assert.Equal(3, attempt);
        }


        [Fact]
        public async System.Threading.Tasks.Task RetryAsync_Generic_ShouldReturnValue()
        {
            var attempt = 0;
            var result = await TaskRetryExtension.RetryAsync<int>(async () =>
            {
                attempt++;
                if (attempt < 2) throw new InvalidOperationException();
                return 99;
            }, attempts: 3);


            Assert.Equal(99, result);
        }


        [Fact]
        public async System.Threading.Tasks.Task RetryAsync_ShouldThrowAfterAllAttempts()
        {
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await TaskRetryExtension.RetryAsync(async () => throw new InvalidOperationException(), attempts: 2));
        }
    }
}