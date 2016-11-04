using System;
using System.Linq.Expressions;

namespace Algebra
{
	internal class ExpressionConverterDifferential : ExpressionConverter
	{
		private ExpressionConverterParameter _parameterConverter;

		public ExpressionConverterDifferential(ExpressionConverterParameter parameterConverter)
		{
			_parameterConverter = parameterConverter;
		}

		protected override Expression ConvertConstantExpression(Expression constExpression) => 
			Expression.Constant(0d);

		protected override Expression ConvertParameterExpression(ParameterExpression parameter) => 
			Expression.Constant(1d);

		protected override Expression ConvertMethodCallExpression(
			MethodCallExpression callExpression, 
			ParameterExpression parameter
			)
		{
			// Due to the task here may only be the sinus function
			if (callExpression.Method.Name == "Sin") {
				return Expression.Multiply(
					Expression.Call(
					typeof(Math).GetMethod("Cos", new[] { typeof(double) }),
					parameter
					),
					Convert(callExpression.Arguments[0], parameter)
					);
			}

			throw new ArgumentException("Wrong function name");
		}

		protected override Expression ConvertAddExpression(
			BinaryExpression binExpression, 
			ParameterExpression parameter
			) => Expression.Add(Convert(binExpression.Left, parameter), Convert(binExpression.Right, parameter));

		protected override Expression ConvertMultiplyExpression(
			BinaryExpression binExpression, 
			ParameterExpression parameter
			) => Expression.Add(
					Expression.Multiply(
						Convert(binExpression.Left, parameter), 
						_parameterConverter.Convert(binExpression.Right, parameter)
						),
					Expression.Multiply(
						_parameterConverter.Convert(binExpression.Left, parameter), 
						Convert(binExpression.Right, parameter)
						)
					);
	}
}