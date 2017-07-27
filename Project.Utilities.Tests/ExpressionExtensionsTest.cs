using System;
using System.Linq.Expressions;
using Xunit;

namespace Project.Utilities.Tests
{
    public class ExpressionExtensionsTest
    {
        [Fact]
        public void GetName_ReturnMethodNameWhenALambdaIsUsed() {
            var funcExpression = (Expression<Func<bool>>) (() => GenericMethodName());

            var name = funcExpression.GetName();

            Assert.Equal("GenericMethodName", name);
        }

        private bool GenericMethodName() => true;
    }
}
