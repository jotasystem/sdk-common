using System.Linq.Expressions;

namespace JotaSystem.Sdk.Common.Extensions.Expression
{
    public static class ExpressionExtension
    {
        #region Predicate starters

        public static Expression<Func<T, bool>> True<T>()
            => _ => true;

        public static Expression<Func<T, bool>> False<T>()
            => _ => false;

        #endregion

        #region Logical composition

        public static Expression<Func<T, bool>> And<T>(
            this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right)
        {
            return Compose(left, right, System.Linq.Expressions.Expression.AndAlso);
        }

        public static Expression<Func<T, bool>> Or<T>(
            this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right)
        {
            return Compose(left, right, System.Linq.Expressions.Expression.OrElse);
        }

        public static Expression<Func<T, bool>> Not<T>(
            this Expression<Func<T, bool>> expression)
        {
            var parameter = expression.Parameters[0];
            var body = System.Linq.Expressions.Expression.Not(expression.Body);
            return System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        #endregion

        #region Core

        private static Expression<Func<T, bool>> Compose<T>(
            Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right,
            Func<System.Linq.Expressions.Expression, System.Linq.Expressions.Expression, BinaryExpression> merge)
        {
            if (left is null)
                return right;

            if (right is null)
                return left;

            var parameter = System.Linq.Expressions.Expression.Parameter(typeof(T));

            var leftBody = ReplaceParameter(left.Body, left.Parameters[0], parameter);
            var rightBody = ReplaceParameter(right.Body, right.Parameters[0], parameter);

            var body = merge(leftBody, rightBody);

            return System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        private static System.Linq.Expressions.Expression ReplaceParameter(
            System.Linq.Expressions.Expression body,
            ParameterExpression source,
            ParameterExpression target)
        {
            return new ParameterReplaceVisitor(source, target).Visit(body);
        }

        #endregion

        #region Visitor

        private sealed class ParameterReplaceVisitor : ExpressionVisitor
        {
            private readonly ParameterExpression _source;
            private readonly ParameterExpression _target;

            public ParameterReplaceVisitor(
                ParameterExpression source,
                ParameterExpression target)
            {
                _source = source;
                _target = target;
            }

            protected override System.Linq.Expressions.Expression VisitParameter(ParameterExpression node)
                => node == _source ? _target : base.VisitParameter(node);
        }

        #endregion
    }
}
