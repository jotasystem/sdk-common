using JotaSystem.Sdk.Common.Extensions.DateTime;
using System;
using Xunit;

namespace JotaSystem.Sdk.Common.Tests.Extensions.DateTime
{
    public class DateTimeFormattingExtensionTest
    {
        [Fact]
        public void ToIsoString_ShouldReturnCorrectFormat()
        {
            var date = new System.DateTime(2025, 10, 9, 15, 30, 45);
            Assert.Equal("2025-10-09T15:30:45", date.ToIsoString());
        }

        [Fact]
        public void ToShortDateStringOrDefault_ShouldReturnDefaultForNull()
        {
            System.DateTime? date = null;
            Assert.Equal("", date.ToShortDateStringOrDefault());
            Assert.Equal("01/01/2000", date.ToShortDateStringOrDefault("01/01/2000"));
        }

        [Fact]
        public void ToFriendlyString_ShouldReturnApproximation()
        {
            var now = System.DateTime.Now;
            var oneMinuteAgo = now.AddMinutes(-1);
            var oneHourAgo = now.AddHours(-1);
            var oneDayAgo = now.AddDays(-1);

            Assert.Equal("agora mesmo", now.ToFriendlyString());
            Assert.Equal("1 minuto(s) atrás", oneMinuteAgo.ToFriendlyString());
            Assert.Equal("1 hora(s) atrás", oneHourAgo.ToFriendlyString());
            Assert.Equal("1 dia(s) atrás", oneDayAgo.ToFriendlyString());
        }
    }
}