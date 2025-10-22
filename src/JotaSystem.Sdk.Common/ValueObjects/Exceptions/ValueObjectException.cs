namespace JotaSystem.Sdk.Common.ValueObjects.Exceptions
{
    /// <summary>
    /// Exceção para erros de Value Objects genéricos no SDK Common.
    /// </summary>
    public class ValueObjectException(string message) : Exception(message)
    {
    }
}