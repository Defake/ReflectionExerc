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

			var dllFilesPaths = Directory.GetFiles(solutionPath, "*.dll", SearchOption.AllDirectories);

			foreach (IPlugin pluginInstance in (
				from pluginTypes in dllFilesPaths
									.Select(Assembly.LoadFrom)
									.Select(assembly => assembly.GetTypes())
				from type in pluginTypes
				select Activator.CreateInstance(type) as IPlugin
				).Where(plugin => plugin != null))
			{
				Console.WriteLine(pluginInstance.Name);
			}
			
			Console.ReadKey();
		}
	}
}
