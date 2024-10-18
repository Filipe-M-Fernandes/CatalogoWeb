using System.Linq.Expressions;

namespace CatalogoWeb.Core
{
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }

        private static Expression<Func<T, bool>> UpdateParameters<T>(Expression<Func<T, bool>> expr, ParameterExpression newParameter)
        {

            var visitor = new ParameterUpdateVisitor(expr.Parameters[0], newParameter);
            var body = visitor.Visit(expr.Body);
            return Expression.Lambda<Func<T, bool>>(body, newParameter);

        }

        public static Expression<Func<T, bool>> InitFind<T>(this Expression<Func<T, bool>> expr)
        {
            return expr;
        }

        public static Expression<Func<T, bool>> AndFind<T>(this Expression<Func<T, bool>> prevexpr, Expression<Func<T, bool>> actexpr)
        {
            Expression<Func<T, bool>> newexpr = UpdateParameters(actexpr, prevexpr.Parameters[0]);
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(prevexpr.Body, newexpr.Body), prevexpr.Parameters[0]);

        }
        public class ParameterUpdateVisitor : ExpressionVisitor
        {
            private ParameterExpression _oldParameter;
            private ParameterExpression _newdParameter;

            public ParameterUpdateVisitor(ParameterExpression oldParameter, ParameterExpression newParameter)
            {
                _oldParameter = oldParameter;
                _newdParameter = newParameter;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                if (object.ReferenceEquals(node, _oldParameter))
                    return _newdParameter;

                return base.VisitParameter(node);
            }

        }
    }
}
