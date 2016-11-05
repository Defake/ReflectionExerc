using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Algebra 
{
	class Program 
	{
		static void Main(string[] args) 
		{
			//Console.WriteLine(lala(8));

			Console.ReadKey();
		}

		//static double lala(double par)
		//{
		//	Expression<Func<double, double>> f = x => x * x + 10 * Math.Sin(4*x*x*x);

		//	var w = Expression.Parameter(typeof(double), "w");
		//	BinaryExpression binaryExpression = Diff(f.Body, w) as BinaryExpression;
			
		//	var lambdaExpression = Expression.Lambda<Func<double, double>>(
		//		binaryExpression,
		//		w
		//		);

		//	var func = lambdaExpression.Compile();

		//	return func(par);
		//}

		//private static Expression Diff(Expression exp, ParameterExpression parameter)
		//{
		//	if (exp is ConstantExpression)
		//		return Expression.Constant(0d);
		//	if (exp is ParameterExpression)
		//		return Expression.Constant(1d);

		//	var callExpression = exp as MethodCallExpression;
		//	if (callExpression != null)
		//	{
		//		// Due to the task here may only be the sinus function
		//		if (callExpression.Method.Name == "Sin")
		//		{
		//			return Expression.Multiply(
		//				Expression.Call(
		//				typeof(Math).GetMethod("Cos", new [] {typeof(double)}),
		//				parameter
		//				),
		//				Diff(callExpression.Arguments[0], parameter)
		//				);
		//		}

		//		throw new ArgumentException("Wrong function name");
		//	}
				

		//	var binExpression = exp as BinaryExpression;
		//	if (binExpression != null)
		//	{
		//		switch (binExpression.NodeType)
		//		{
		//			case ExpressionType.Add:
		//				return Expression.Add(Diff(binExpression.Left, parameter), Diff(binExpression.Right, parameter));
		//			case ExpressionType.Multiply:
		//				return Expression.Add(
		//					Expression.Multiply(Diff(binExpression.Left, parameter), ArgumentConverter(binExpression.Right, parameter)),
		//					Expression.Multiply(ArgumentConverter(binExpression.Left, parameter), Diff(binExpression.Right, parameter))
		//					);
		//		}
				
		//	}

		//	throw new ArgumentException("Unknown expression type");
		//}

		//private static Expression ArgumentConverter(Expression exp, ParameterExpression parameter)
		//{
		//	if (exp is ConstantExpression)
		//		return exp;
		//	if (exp is ParameterExpression)
		//		return parameter;

		//	var callExpression = exp as MethodCallExpression;
		//	if (callExpression != null)
		//		return Expression.Call(
		//			typeof(Math).GetMethod(callExpression.Method.Name, new[] { typeof(double) }),
		//			parameter
		//			);

		//	var binExpression = exp as BinaryExpression;
		//	if (binExpression != null) {
		//		switch (binExpression.NodeType) {
		//			case ExpressionType.Add:
		//				return Expression.Add(
		//					ArgumentConverter(binExpression.Left, parameter), 
		//					ArgumentConverter(binExpression.Right, parameter)
		//					);
		//			case ExpressionType.Multiply:
		//				return Expression.Multiply(
		//					ArgumentConverter(binExpression.Left, parameter), 
		//					ArgumentConverter(binExpression.Right, parameter)
		//					);
		//		}

		//	}

		//	throw new ArgumentException("Unknown expression type");
		//}

	}
}
