using JotaSystem.Sdk.Common.Helpers;

namespace JotaSystem.Sdk.Common.Tests.Helpers
{
    public class UrlHelperTests
    {
        [Theory]
        [InlineData("https://www.example.com", true)]
        [InlineData("http://example.com", true)]
        [InlineData("ftp://example.com", false)]
        [InlineData("not-a-url", false)]
        [InlineData("", false)]
        public void IsValidUrl_ShouldReturnExpected(string url, bool expected)
        {
            var result = UrlHelper.IsValidUrl(url);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AddQueryParameters_ShouldAddParametersToUrl()
        {
            var url = "https://example.com";
            var parameters = new Dictionary<string, string>
            {
                { "a", "1" },
                { "b", "2" }
            };

            var result = UrlHelper.AddQueryParameters(url, parameters);

            Assert.Contains("a=1", result);
            Assert.Contains("b=2", result);
            Assert.StartsWith(url, result);
        }

        [Fact]
        public void AddQueryParameters_ShouldMergeWithExistingQuery()
        {
            var url = "https://example.com?x=9";
            var parameters = new Dictionary<string, string>
            {
                { "y", "10" }
            };

            var result = UrlHelper.AddQueryParameters(url, parameters);

            Assert.Contains("x=9", result);
            Assert.Contains("y=10", result);
        }

        [Fact]
        public void AddQueryParameters_ShouldReturnOriginal_WhenParametersEmpty()
        {
            var url = "https://example.com";
            var result = UrlHelper.AddQueryParameters(url, new Dictionary<string, string>());
            Assert.Equal(url, result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void AddQueryParameters_ShouldThrow_WhenUrlInvalid(string url)
        {
            Assert.Throws<ArgumentException>(() => UrlHelper.AddQueryParameters(url, new Dictionary<string, string>()));
        }

        [Fact]
        public void GetDomain_ShouldReturnHostFromUrl()
        {
            var url = "https://sub.example.com/path?query=1";
            var domain = UrlHelper.GetDomain(url);
            Assert.Equal("sub.example.com", domain);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void GetDomain_ShouldThrow_WhenUrlNullOrEmpty(string url)
        {
            Assert.Throws<ArgumentException>(() => UrlHelper.GetDomain(url));
        }

        [Fact]
        public void GetDomain_ShouldThrow_WhenUrlInvalid()
        {
            var url = "invalid-url";
            Assert.Throws<ArgumentException>(() => UrlHelper.GetDomain(url));
        }
    }
}