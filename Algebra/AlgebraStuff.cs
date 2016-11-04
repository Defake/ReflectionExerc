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
			var diffConverter = new ExpressionConverterDifferential(new ExpressionConverterParameter());

			var y = Expression.Parameter(typeof(double), "y");
			BinaryExpression binaryExpression = diffConverter.Convert(expression.Body, y) as BinaryExpression;

			var lambdaExpression = Expression.Lambda<Func<double, double>>(
				binaryExpression,
				y
				);

			return lambdaExpression;
		}
	}
}

