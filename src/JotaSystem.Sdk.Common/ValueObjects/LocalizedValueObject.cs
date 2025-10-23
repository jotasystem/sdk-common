using JotaSystem.Sdk.Common.Localization;
using JotaSystem.Sdk.Common.Localization.Messages;
using JotaSystem.Sdk.Common.ValueObjects.Base;
using JotaSystem.Sdk.Common.ValueObjects.Exceptions;
using System.Globalization;

namespace JotaSystem.Sdk.Common.ValueObjects
{
    public class LocalizedValueObject : ValueObjectBase
    {
        public string Portuguese { get; private set; } = string.Empty;
        public string English { get; private set; } = string.Empty;
        public string Spanish { get; private set; } = string.Empty;

        protected LocalizedValueObject() { } // EF Core

        public LocalizedValueObject(string portuguese, string english, string spanish, Language? lang = null)
        {
            if (string.IsNullOrWhiteSpace(portuguese))
                throw new ValueObjectException(ValidationMessage.RequiredField(nameof(Portuguese), lang));

            if (string.IsNullOrWhiteSpace(english))
                throw new ValueObjectException(ValidationMessage.RequiredField(nameof(English), lang));

            if (string.IsNullOrWhiteSpace(spanish))
                throw new ValueObjectException(ValidationMessage.RequiredField(nameof(Spanish), lang));

            Portuguese = portuguese.Trim().Normalize();
            English = english.Trim().Normalize();
            Spanish = spanish.Trim().Normalize();
        }

        public override string ToString()
        {
            var culture = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

            return culture switch
            {
                "en" => !string.IsNullOrWhiteSpace(English) ? English : Portuguese,
                "es" => !string.IsNullOrWhiteSpace(Spanish) ? Spanish : Portuguese,
                _ => Portuguese
            };
        }

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Portuguese;
            yield return English;
            yield return Spanish;
        }
    }
}