using JotaSystem.Sdk.Common.Extensions.DateTime;

namespace JotaSystem.Sdk.Common.Tests.Extensions.DateTime
{
    public class DateTimeComparisonExtensionTest
    {
        [Fact]
        public void IsWeekend_ShouldReturnTrueForSaturdayAndSunday()
        {
            Assert.True(new System.DateTime(2025, 10, 11).IsWeekend()); // Sábado
            Assert.True(new System.DateTime(2025, 10, 12).IsWeekend()); // Domingo
            Assert.False(new System.DateTime(2025, 10, 13).IsWeekend()); // Segunda
        }

        [Fact]
        public void IsWeekday_ShouldReturnTrueForMondayToFriday()
        {
            Assert.True(new System.DateTime(2025, 10, 13).IsWeekday()); // Segunda
            Assert.False(new System.DateTime(2025, 10, 12).IsWeekday()); // Domingo
        }

        [Fact]
        public void IsToday_ShouldReturnTrueOnlyForToday()
        {
            var today = System.DateTime.Today;
            var yesterday = today.AddDays(-1);

            Assert.True(today.IsToday());
            Assert.False(yesterday.IsToday());
        }

        [Fact]
        public void IsLeapYear_ShouldReturnCorrectly()
        {
            Assert.True(new System.DateTime(2024, 1, 1).IsLeapYear());
            Assert.False(new System.DateTime(2025, 1, 1).IsLeapYear());
        }
    }
}