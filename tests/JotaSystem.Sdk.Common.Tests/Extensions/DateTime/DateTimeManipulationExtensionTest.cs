using JotaSystem.Sdk.Common.Extensions.DateTime;

namespace JotaSystem.Sdk.Common.Tests.Extensions.DateTime
{
    public class DateTimeManipulationExtensionTest
    {
        [Fact]
        public void AddBusinessDays_ShouldSkipWeekends()
        {
            var friday = new System.DateTime(2025, 10, 10); // Sexta
            var nextMonday = friday.AddBusinessDays(1);
            Assert.Equal(new System.DateTime(2025, 10, 13), nextMonday);

            var monday = new System.DateTime(2025, 10, 13);
            var previousFriday = monday.AddBusinessDays(-1);
            Assert.Equal(new System.DateTime(2025, 10, 10), previousFriday);
        }

        [Fact]
        public void NextDayOfWeek_ShouldReturnCorrectDay()
        {
            var date = new System.DateTime(2025, 10, 9); // Quinta
            var nextMonday = date.NextDayOfWeek(DayOfWeek.Monday);
            Assert.Equal(new System.DateTime(2025, 10, 13), nextMonday);
        }

        [Fact]
        public void PreviousDayOfWeek_ShouldReturnCorrectDay()
        {
            var date = new System.DateTime(2025, 10, 9); // Quinta
            var previousMonday = date.PreviousDayOfWeek(DayOfWeek.Monday);
            Assert.Equal(new System.DateTime(2025, 10, 6), previousMonday);
        }

        [Fact]
        public void AddMonthsSafe_ShouldHandleEndOfMonth()
        {
            var date = new System.DateTime(2025, 1, 31);
            var result = date.AddMonthsSafe(1);
            Assert.Equal(new System.DateTime(2025, 2, 28), result);
        }

        [Fact]
        public void AddYearsSafe_ShouldHandleLeapYears()
        {
            var date = new System.DateTime(2024, 2, 29);
            var result = date.AddYearsSafe(1);
            Assert.Equal(new System.DateTime(2025, 2, 28), result);
        }
    }
}
