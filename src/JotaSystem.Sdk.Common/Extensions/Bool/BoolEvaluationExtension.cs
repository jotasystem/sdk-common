namespace JotaSystem.Sdk.Common.Extensions.Bool
{
    /// <summary>
    /// Extensões para avaliação e execução condicional com base em booleanos.
    /// </summary>
    public static class BoolEvaluationExtension
    {
        /// <summary>
        /// Retorna <paramref name="trueValue"/> se verdadeiro, caso contrário <paramref name="falseValue"/>.
        /// </summary>
        public static T IfTrue<T>(this bool condition, T trueValue, T falseValue)
            => condition ? trueValue : falseValue;

        /// <summary>
        /// Executa uma ação se a condição for verdadeira.
        /// </summary>
        /// <param name="condition">Condição booleana.</param>
        /// <param name="action">Ação a ser executada.</param>
        /// <returns>O próprio valor da condição (para encadeamento).</returns>
        public static bool IfTrue(this bool condition, Action action)
        {
            if (condition) action?.Invoke();
            return condition;
        }

        /// <summary>
        /// Executa uma ação se a condição for falsa.
        /// </summary>
        /// <param name="condition">Condição booleana.</param>
        /// <param name="action">Ação a ser executada.</param>
        /// <returns>O próprio valor da condição (para encadeamento).</returns>
        public static bool IfFalse(this bool condition, Action action)
        {
            if (!condition) action?.Invoke();
            return condition;
        }

        /// <summary>
        /// Retorna o valor original ou um alternativo se falso.
        /// </summary>
        public static bool OrIfFalse(this bool value, bool alternate) => value ? value : alternate;

        /// <summary>
        /// Retorna o valor original ou um alternativo se verdadeiro.
        /// </summary>
        public static bool OrIfTrue(this bool value, bool alternate) => value ? alternate : value;

        /// <summary>
        /// Avalia se um objeto é "verdadeiro", aceitando bool, string e números.
        /// </summary>
        public static bool IsTruthy(this object? value)
        {
            if (value is null) return false;
            if (value is bool b) return b;
            if (value is string s) return s.ToBool();
            if (value is int i) return i != 0;
            if (value is decimal d) return d != 0;
            if (value is double db) return db != 0;
            return true;
        }
    }
}