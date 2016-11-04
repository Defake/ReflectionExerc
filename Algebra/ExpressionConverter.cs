using System;
using System.Linq.Expressions;

namespace Algebra
{
	internal abstract class ExpressionConverter
	{
		public Expression Convert(Expression exp, ParameterExpression parameter)
		{
			if (exp is ConstantExpression)
				return ConvertConstantExpression(exp);
			if (exp is ParameterExpression)
				return ConvertParameterExpression(parameter);

			var callExpression = exp as MethodCallExpression;
			if (callExpression != null)
				return ConvertMethodCallExpression(callExpression, parameter);

			var binExpression = exp as BinaryExpression;
			if (binExpression != null) {
				switch (binExpression.NodeType) {
					case ExpressionType.Add:
						return ConvertAddExpression(binExpression, parameter);
					case ExpressionType.Multiply:
						return ConvertMultiplyExpression(binExpression, parameter);
				}

			}

			throw new ArgumentException("Unknown expression type");
		}

		protected abstract Expression ConvertConstantExpression(Expression constExpression);
		protected abstract Expression ConvertParameterExpression(ParameterExpression parameter);
		protected abstract Expression ConvertMethodCallExpression(MethodCallExpression callExpression, ParameterExpression parameter);
		protected abstract Expression ConvertAddExpression(BinaryExpression binExpression, ParameterExpression parameter);
		protected abstract Expression ConvertMultiplyExpression(BinaryExpression binExpression, ParameterExpression parameter);

	}
}