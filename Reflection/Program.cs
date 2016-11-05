using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Framework;

namespace Reflection 
{
	class Program
	{
		static void Main(string[] args) 
		{
			//var sampleAssembly = Assembly.LoadFrom(@"D:\Programming\VisualStudio\Projects\STUDYING_Csharp\Reflection\Reflection\DLLs\Plugin1.dll");

			const string solutionPath = @"D:\Programming\VisualStudio\Projects\STUDYING_Csharp\Reflection\";

			var dllFilesPaths = Directory.GetFiles(solutionPath, "Plugin*.dll", SearchOption.AllDirectories);

			foreach (var pluginInstance in dllFilesPaths
				.Select(Assembly.LoadFrom)
				.SelectMany(assembly => assembly.GetTypes())
				.Where(type => type.GetInterface("IPlugin") != null)
				.Where(type => type.GetConstructor(Type.EmptyTypes) != null)
				.Select(type => Activator.CreateInstance(type) as IPlugin)
				)
			{
				Console.WriteLine(pluginInstance.Name);
			}

			Console.ReadKey();
		}
	}
}
