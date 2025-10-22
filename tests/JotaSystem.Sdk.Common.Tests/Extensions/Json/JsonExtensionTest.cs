using JotaSystem.Sdk.Common.Extensions.Json;

namespace JotaSystem.Sdk.Common.Tests.Extensions.Json
{
    public class JsonExtensionTest
    {
        private class TestObj { public int X { get; set; } = 10; public string Y { get; set; } = "Test"; }


        [Fact]
        public void ToJson_ShouldSerializeObject()
        {
            var obj = new TestObj();
            var json = obj.ToJson();
            Assert.Contains("x", json);
            Assert.Contains("y", json);
        }

        [Fact]
        public void FromJson_ShouldDeserializeObject()
        {
            var obj = new TestObj();
            var json = obj.ToJson();
            var deserialized = json.FromJson<TestObj>();
            Assert.Equal(obj.X, deserialized.X);
            Assert.Equal(obj.Y, deserialized.Y);
        }

        [Fact]
        public void TryFromJson_ShouldReturnFalse_ForInvalidJson()
        {
            var invalidJson = "{ invalid json }";
            var success = invalidJson.TryFromJson<TestObj>(out var result);
            Assert.False(success);
            Assert.Null(result);
        }

        [Fact]
        public void CloneJson_ShouldReturnDeepCopy()
        {
            var obj = new TestObj();
            var clone = obj.CloneJson();
            Assert.Equal(obj.X, clone.X);
            Assert.Equal(obj.Y, clone.Y);
            Assert.NotSame(obj, clone);
        }

        [Fact]
        public void PrettyPrint_ShouldReturnFormattedJson()
        {
            var obj = new TestObj();
            var json = obj.ToJson();
            var pretty = json.PrettyPrint();
            Assert.Contains("\n", pretty); // contém quebra de linha
        }
    }
}