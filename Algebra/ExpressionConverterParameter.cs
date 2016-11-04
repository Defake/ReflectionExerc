using System;
using System.Linq.Expressions;

namespace Algebra
{
	internal class ExpressionConverterParameter : ExpressionConverter
	{
		protected override Expression ConvertConstantExpression(Expression constExpression) => constExpression;

		protected override Expression ConvertParameterExpression(ParameterExpression parameter) => parameter;

		protected override Expression ConvertMethodCallExpression(MethodCallExpression callExpression, ParameterExpression parameter)
		{
			return Expression.Call(
					typeof(Math).GetMethod(callExpression.Method.Name, new[] { typeof(double) }),
					parameter
					);
		}

		protected override Expression ConvertAddExpression(BinaryExpression binExpression, ParameterExpression parameter)
		{
			return Expression.Add(
				Convert(binExpression.Left, parameter), 
				Convert(binExpression.Right, parameter)
				);
		}

		protected override Expression ConvertMultiplyExpression(BinaryExpression binExpression, ParameterExpression parameter)
		{
			return Expression.Multiply(
				Convert(binExpression.Left, parameter),
				Convert(binExpression.Right, parameter)
				);
		}
	}
}