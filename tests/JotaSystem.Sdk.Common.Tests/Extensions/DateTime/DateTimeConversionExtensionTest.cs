using JotaSystem.Sdk.Common.Extensions.DateTime;

namespace JotaSystem.Sdk.Common.Tests.Extensions.DateTime
{
    public class DateTimeConversionExtensionTest
    {
        [Fact]
        public void UnixTimestampConversion_ShouldBeAccurate()
        {
            var date = new System.DateTime(2025, 10, 9, 12, 0, 0, DateTimeKind.Utc);
            var timestamp = date.ToUnixTimestamp();
            var back = timestamp.FromUnixTimestamp();
            Assert.Equal(date, back);
        }

        [Fact]
        public void ToUtcSafe_ShouldNotChangeUtcDate()
        {
            var date = new System.DateTime(2025, 10, 9, 12, 0, 0, DateTimeKind.Utc);
            Assert.Equal(date, date.ToUtcSafe());
        }

        [Fact]
        public void ToLocalTimeSafe_ShouldNotChangeLocalDate()
        {
            var localDate = System.DateTime.Now;
            Assert.Equal(localDate, localDate.ToLocalTimeSafe());
        }
    }
}