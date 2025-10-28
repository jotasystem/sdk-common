using JotaSystem.Sdk.Common.Localization;
using JotaSystem.Sdk.Common.Localization.Messages;

namespace JotaSystem.Sdk.Common.Tests.Localization.Messages
{
    public class ValidationMessageTest
    {
        [Theory]
        [InlineData(Language.PtBr, "Nome não pode ser vazio.")]
        [InlineData(Language.EnUs, "Name cannot be empty.")]
        [InlineData(Language.EsEs, "Nombre no puede estar vacío.")]
        public void RequiredField_ShouldReturnLocalizedMessage(Language lang, string expected)
        {
            var message = ValidationMessage.RequiredField(lang == Language.EsEs ? "Nombre" : lang == Language.EnUs ? "Name" : "Nome", lang);
            Assert.Equal(expected, message);
        }

        [Theory]
        [InlineData(Language.PtBr, "Nome é obrigatório.")]
        [InlineData(Language.EnUs, "Name is required.")]
        [InlineData(Language.EsEs, "Nombre es obligatorio.")]
        public void IsRequired_ShouldReturnLocalizedMessage(Language lang, string expected)
        {
            // Arrange
            var fieldName = lang switch
            {
                Language.EnUs => "Name",
                Language.EsEs => "Nombre",
                _ => "Nome"
            };

            // Act
            var message = ValidationMessage.IsRequired(fieldName, lang);

            // Assert
            Assert.Equal(expected, message);
        }

        [Theory]
        [InlineData(Language.PtBr, "Email é inválido.")]
        [InlineData(Language.EnUs, "Email is invalid.")]
        [InlineData(Language.EsEs, "Correo es inválido.")]
        public void InvalidField_ShouldReturnLocalizedMessage(Language lang, string expected)
        {
            var field = lang == Language.EsEs ? "Correo" : lang == Language.EnUs ? "Email" : "Email";
            var message = ValidationMessage.InvalidField(field, lang);
            Assert.Equal(expected, message);
        }

        [Theory]
        [InlineData(Language.PtBr, "Senha possui um formato inválido.")]
        [InlineData(Language.EnUs, "Password has an invalid format.")]
        [InlineData(Language.EsEs, "Contraseña tiene un formato inválido.")]
        public void InvalidFormat_ShouldReturnLocalizedMessage(Language lang, string expected)
        {
            var field = lang == Language.EsEs ? "Contraseña" : lang == Language.EnUs ? "Password" : "Senha";
            var message = ValidationMessage.InvalidFormat(field, lang);
            Assert.Equal(expected, message);
        }

        [Theory]
        [InlineData(Language.PtBr, "Código deve ter no mínimo 3 caracteres.")]
        [InlineData(Language.EnUs, "Code must at minimum 3 characters.")]
        [InlineData(Language.EsEs, "Código debe tener al menos 3 caracteres.")]
        public void MinLength_ShouldReturnLocalizedMessage(Language lang, string expected)
        {
            var field = lang == Language.EsEs ? "Código" : lang == Language.EnUs ? "Code" : "Código";
            var message = ValidationMessage.MinLength(field, 3, lang);
            Assert.Equal(expected, message);
        }

        [Theory]
        [InlineData(Language.PtBr, "Código deve ter no máximo 10 caracteres.")]
        [InlineData(Language.EnUs, "Code must at maximum 10 characters.")]
        [InlineData(Language.EsEs, "Código debe tener al máximo 10 caracteres.")]
        public void MaxLength_ShouldReturnLocalizedMessage(Language lang, string expected)
        {
            var field = lang == Language.EsEs ? "Código" : lang == Language.EnUs ? "Code" : "Código";
            var message = ValidationMessage.MaxLength(field, 10, lang);
            Assert.Equal(expected, message);
        }

        [Theory]
        [InlineData(Language.PtBr, "Código deve ter 6 caracteres.")]
        [InlineData(Language.EnUs, "Code must have 6 characters.")]
        [InlineData(Language.EsEs, "Código debe tener 6 caracteres.")]
        public void InvalidLength_ShouldReturnLocalizedMessage(Language lang, string expected)
        {
            var field = lang == Language.EsEs ? "Código" : lang == Language.EnUs ? "Code" : "Código";
            var message = ValidationMessage.InvalidLength(field, 6, lang);
            Assert.Equal(expected, message);
        }

        [Theory]
        [InlineData(Language.PtBr, "Usuário deve ter entre 3 e 10 caracteres.")]
        [InlineData(Language.EnUs, "User must have between 3 and 10 characters.")]
        [InlineData(Language.EsEs, "Usuario debe tener entre 3 y 10 caracteres.")]
        public void LengthOutOfRange_ShouldReturnLocalizedMessage(Language lang, string expected)
        {
            var field = lang == Language.EsEs ? "Usuario" : lang == Language.EnUs ? "User" : "Usuário";
            var message = ValidationMessage.LengthOutOfRange(field, 3, 10, lang);
            Assert.Equal(expected, message);
        }

        [Fact]
        public void RequiredField_ShouldUseDefaultLanguage_WhenNull()
        {
            LanguageProvider.SetDefault(Language.EnUs);
            var message = ValidationMessage.RequiredField("Email");
            Assert.Equal("Email cannot be empty.", message);

            // Reset
            LanguageProvider.SetDefault(Language.PtBr);
        }
    }
}