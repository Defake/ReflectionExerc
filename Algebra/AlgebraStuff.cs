using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Algebra 
{
	public static class AlgebraLambdaExtensions
	{
		public static Expression<Func<double, double>> Differentiate(this Expression<Func<double, double>> expression)
		{
			BinaryExpression binaryExpression = Diff(expression.Body, expression.Parameters[0]) as BinaryExpression;

			if (binaryExpression == null) return null;

			return Expression.Lambda<Func<double, double>>(
				binaryExpression,
				expression.Parameters[0]
				);
		}

		private static Expression Diff(Expression exp, ParameterExpression parameter) 
		{
			switch (exp.NodeType) 
			{
				case ExpressionType.Constant:
					return Expression.Constant(0d);
				case ExpressionType.Parameter:
					return Expression.Constant(1d);
				case ExpressionType.Call:
					var callExpression = exp as MethodCallExpression;
					// Due to the task here may only be the sinus function
					if (callExpression?.Method.Name == "Sin") {
						return Expression.Multiply(
							Expression.Call(
							typeof(Math).GetMethod("Cos", new[] { typeof(double) }),
							parameter
							),
							Diff(callExpression.Arguments[0], parameter)
							);
					}
					throw new ArgumentException("Wrong function name");
				case ExpressionType.Add:
					var addExpression = exp as BinaryExpression;
					if (addExpression != null)
						return Expression.Add(Diff(addExpression.Left, parameter), Diff(addExpression.Right, parameter));
					break;
				case ExpressionType.Multiply:
					var multiplyExpression = exp as BinaryExpression;
					if (multiplyExpression != null)
						return Expression.Add(
							Expression.Multiply(Diff(multiplyExpression.Left, parameter), multiplyExpression.Right),
							Expression.Multiply(multiplyExpression.Left, Diff(multiplyExpression.Right, parameter))
							);
					break;
			}

			throw new ArgumentException("Unknown expression type");
		}

	}
}

