using System;
using System.Linq.Expressions;

namespace Garbage.Utilities {
    public static class ExpressionExtensions {
        public static string GetName<T>(this Expression<Func<T>> predicate) {
            if (predicate.NodeType != ExpressionType.Lambda)
                return string.Empty;

            var info = (MethodCallExpression) predicate.Body;
            return info.Method.Name;
        }
    }
}