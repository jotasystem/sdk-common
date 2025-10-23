using JotaSystem.Sdk.Common.Helpers;

namespace JotaSystem.Sdk.Common.Tests.Helpers
{
    public class FileHelperTest : IDisposable
    {
        private readonly string _tempFile;

        public FileHelperTest()
        {
            _tempFile = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.txt");
        }

        public void Dispose()
        {
            if (File.Exists(_tempFile))
                File.Delete(_tempFile);
        }

        [Fact]
        public void Exists_ShouldReturnFalse_WhenFileDoesNotExist()
        {
            Assert.False(FileHelper.Exists(_tempFile));
        }

        [Fact]
        public void CreateIfNotExists_ShouldCreateFile()
        {
            FileHelper.CreateIfNotExists(_tempFile);
            Assert.True(File.Exists(_tempFile));
        }

        [Fact]
        public void ReadFile_ShouldReturnEmpty_WhenFileDoesNotExist()
        {
            var content = FileHelper.ReadFile(_tempFile);
            Assert.Equal(string.Empty, content);
        }

        [Fact]
        public void WriteFile_ShouldWriteContentToFile()
        {
            var text = "Hello World!";
            FileHelper.WriteFile(_tempFile, text);

            var content = File.ReadAllText(_tempFile);
            Assert.Equal(text, content);
        }

        [Fact]
        public void ReadFile_ShouldReturnWrittenContent()
        {
            var text = "Sample Content";
            File.WriteAllText(_tempFile, text);

            var content = FileHelper.ReadFile(_tempFile);
            Assert.Equal(text, content);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Methods_ShouldThrow_WhenPathIsNullOrWhitespace(string? path)
        {
            Assert.Throws<ArgumentException>(() => FileHelper.Exists(path!));
            Assert.Throws<ArgumentException>(() => FileHelper.CreateIfNotExists(path!));
            Assert.Throws<ArgumentException>(() => FileHelper.ReadFile(path!));
            Assert.Throws<ArgumentException>(() => FileHelper.WriteFile(path!, "test"));
        }

        [Fact]
        public void WriteFile_ShouldHandleNullContent()
        {
            FileHelper.WriteFile(_tempFile, null!);
            var content = File.ReadAllText(_tempFile);
            Assert.Equal(string.Empty, content);
        }
    }
}