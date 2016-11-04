using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algebra.Test {

	[TestClass]
	public class Test {

		[TestMethod]
		public void SimpleTest() {
			Expression<Func<double, double>> f = x => x * x;
			Expression<Func<double, double>> df = f.Differentiate();

			Console.WriteLine("f  = {0}", f);   //f  = x => (x * x)
			Console.WriteLine("df = {0}", df);  //df = x => (x + x)

			Func<double, double> compiled = df.Compile();
			double result = compiled.Invoke(12);
			Console.WriteLine(result);          //24
		}

		[TestMethod]
		public void SinTest() {
			Expression<Func<double, double>> f = x => (10 + Math.Sin(x)) * x;
			Expression<Func<double, double>> df = f.Differentiate();

			Console.WriteLine("f  = {0}", f);   //f  = x => ((10 + Sin(x)) * x)
			Console.WriteLine("df = {0}", df);  //df = x => ((10 + Sin(x)) + (Cos(x) * x))

			Func<double, double> compiled = df.Compile();
			double result = compiled.Invoke(12);
			Console.WriteLine(result);          //19,5896745867895
		}
	}
}
