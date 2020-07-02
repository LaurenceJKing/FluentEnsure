using System;
using System.Linq.Expressions;

namespace FluentEnsure
{
    public static class ExpressionHelper
    {
        public static string FullName<T, TMember>(
            this Expression<Func<T, TMember>> expression) =>
            expression.Body switch
            {
                MemberExpression e => e.FullName(),
                _ => expression.Name
            };

        public static string FullName<T>(
            this Expression<Func<T>> expression) =>
            expression.Body switch
            {
                MemberExpression e => e.FullName(),
                ConstantExpression e => e.Value.ToString(),
                _ => expression.Name
            };

        private static string FullName(
            this MemberExpression? member)
        {
            var parts = "";

            while (member != null)
            {
                parts = member.Member.Name + "." + parts;
                member = member.Expression as MemberExpression;
            }

            return parts.TrimEnd('.');
        }
    }
}