using JotaSystem.Sdk.Common.Extensions.DateTime;
using System;
using Xunit;

namespace JotaSystem.Sdk.Common.Tests.Extensions.DateTime
{
    public class DateTimePeriodExtensionTest
    {
        [Fact]
        public void StartAndEndOfDay_ShouldReturnCorrectTimes()
        {
            var date = new System.DateTime(2025, 10, 9, 15, 30, 45);
            Assert.Equal(new System.DateTime(2025, 10, 9, 0, 0, 0), date.StartOfDay());
            Assert.Equal(new System.DateTime(2025, 10, 9, 23, 59, 59, 999), date.EndOfDay());
        }

        [Fact]
        public void StartAndEndOfMonth_ShouldReturnCorrectDates()
        {
            var date = new System.DateTime(2025, 2, 15); // Fevereiro não bissexto
            Assert.Equal(new System.DateTime(2025, 2, 1), date.StartOfMonth());
            Assert.Equal(new System.DateTime(2025, 2, 28, 23, 59, 59, 999), date.EndOfMonth());
        }

        [Fact]
        public void DaysInMonth_ShouldReturnCorrectNumberOfDays()
        {
            // Arrange
            var january = new System.DateTime(2025, 1, 10); // 31 dias
            var februaryNonLeap = new System.DateTime(2025, 2, 10); // 28 dias
            var februaryLeap = new System.DateTime(2024, 2, 10); // 29 dias
            var april = new System.DateTime(2025, 4, 10); // 30 dias
            var december = new System.DateTime(2025, 12, 10); // 31 dias

            // Act & Assert
            Assert.Equal(31, january.DaysInMonth());
            Assert.Equal(28, februaryNonLeap.DaysInMonth());
            Assert.Equal(29, februaryLeap.DaysInMonth());
            Assert.Equal(30, april.DaysInMonth());
            Assert.Equal(31, december.DaysInMonth());
        }

        [Fact]
        public void StartAndEndOfYear_ShouldReturnCorrectDates()
        {
            var date = new System.DateTime(2025, 5, 10);
            Assert.Equal(new System.DateTime(2025, 1, 1), date.StartOfYear());
            Assert.Equal(new System.DateTime(2025, 12, 31, 23, 59, 59, 999), date.EndOfYear());
        }

        [Fact]
        public void StartAndEndOfWeek_ShouldReturnCorrectDates()
        {
            var date = new System.DateTime(2025, 10, 9); // Quinta
            Assert.Equal(new System.DateTime(2025, 10, 6), date.StartOfWeek()); // Segunda
            Assert.Equal(new System.DateTime(2025, 10, 12, 23, 59, 59, 999), date.EndOfWeek());
        }
    }
}