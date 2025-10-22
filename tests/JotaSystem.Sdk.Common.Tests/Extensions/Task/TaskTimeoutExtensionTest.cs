using JotaSystem.Sdk.Common.Extensions.Task;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Task
{
    public class TaskTimeoutExtensionTest
    {
        [Fact]
        public async System.Threading.Tasks.Task WithTimeout_ShouldComplete_WhenTaskFinishesBeforeTimeout()
        {
            await System.Threading.Tasks.Task.Delay(50).WithTimeout(TimeSpan.FromSeconds(1));
        }


        [Fact]
        public async System.Threading.Tasks.Task WithTimeout_ShouldThrowTimeoutException_WhenExceedsTimeout()
        {
            await Assert.ThrowsAsync<TimeoutException>(async () =>
            await System.Threading.Tasks.Task.Delay(500).WithTimeout(TimeSpan.FromMilliseconds(50)));
        }


        [Fact]
        public async System.Threading.Tasks.Task WithTimeoutOrDefault_ShouldReturnDefault_OnTimeout()
        {
            var result = await System.Threading.Tasks.Task.Delay(200)
            .ContinueWith(_ => 42)
            .WithTimeoutOrDefault(TimeSpan.FromMilliseconds(20), -1);
            Assert.Equal(-1, result);
        }
    }
}