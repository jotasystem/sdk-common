using JotaSystem.Sdk.Common.Extensions.Task;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Task
{
    public class TaskConvenienceExtensionTest
    {
        [Fact]
        public async System.Threading.Tasks.Task TryAwait_ShouldReturnTrue_WhenTaskSucceeds()
        {
            var ok = await System.Threading.Tasks.Task.CompletedTask.TryAwait();
            Assert.True(ok);
        }


        [Fact]
        public async System.Threading.Tasks.Task TryAwait_ShouldReturnFalse_WhenTaskThrows()
        {
            var task = System.Threading.Tasks.Task.Run(() => throw new InvalidOperationException());
            var ok = await task.TryAwait();
            Assert.False(ok);
        }


        [Fact]
        public async System.Threading.Tasks.Task TryAwait_Generic_ShouldReturnDefault_OnException()
        {
            var failing = System.Threading.Tasks.Task.Run((Func<int>)(() => throw new InvalidOperationException()));
            var result = await failing.TryAwait(-1);
            Assert.Equal(-1, result);
        }
    }
}