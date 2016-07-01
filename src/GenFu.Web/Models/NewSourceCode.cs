using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace GenFu.Web.Models
{
	public class NewSourceCode
	{
		public CompileResult Compile()
		{
			var result = new CompileResult();

			string code = CreateFunctionCode();
			var syntaxTree = CSharpSyntaxTree.ParseText(code);

			MetadataReference[] references = new MetadataReference[]
			{
						//MetadataReference.
						MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location),
						MetadataReference.CreateFromFile(typeof(Hashtable).GetTypeInfo().Assembly.Location)
			};

			var compilation = CSharpCompilation.Create("Function.dll",
			   syntaxTrees: new[] { syntaxTree },
			   references: references,
			   options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

			StringBuilder message = new StringBuilder();

			using (var ms = new MemoryStream())
			{
				EmitResult emitResult = compilation.Emit(ms);

				if (!emitResult.Success)
				{
					IEnumerable<Diagnostic> failures = emitResult.Diagnostics.Where(diagnostic =>
						diagnostic.IsWarningAsError ||
						diagnostic.Severity == DiagnosticSeverity.Error);

					foreach (Diagnostic diagnostic in failures)
					{
						message.AppendFormat("{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
					}

					throw new Exception("The following compile errors were encountered: " + message.ToString());
				}
				else
				{
					ms.Seek(0, SeekOrigin.Begin);

#if NET451
							Assembly assembly = Assembly.Load(ms.ToArray());
#else
					AssemblyLoadContext context = AssemblyLoadContext.Default;
					Assembly assembly = context.LoadFromStream(ms);
#endif

					Type mappingFunction = assembly.GetType("Program");
					// = mappingFunction.GetMethod("CustomFunction");
					//_resetMethod = mappingFunction.GetMethod("Reset");
				}

				return result;
			}
		}

		private string CreateFunctionCode()
		{
			throw new NotImplementedException();
		}
	}
}