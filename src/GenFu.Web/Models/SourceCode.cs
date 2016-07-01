using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Globalization;
//using Microsoft.Dnx.Compilation;
//using Microsoft.Dnx.Runtime;
//using Microsoft.Dnx.Compilation.CSharp;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.DotNet.ProjectModel.Compilation;
using System.Runtime.Loader;
using Microsoft.VisualStudio.Web.CodeGeneration.DotNet;
//using Microsoft.VisualStudio.Web.CodeGeneration.DotNet;

namespace GenFu.Web.Models
{
	public static class SourceCodeHelpers
	{
		public static readonly Type[] SupportedTypes = new Type[]
		{
			typeof(Object),
			typeof(short),
			typeof(float),
			typeof(Int32),
			typeof(Int16),
			typeof(double),
			typeof(decimal),
			typeof(Guid),
			typeof(long),
			typeof(ulong),
			typeof(uint),
			typeof(ushort),
			typeof(bool),
			typeof(string),
			typeof(DateTime)
		};

		public static MetadataReference GetMeta(this Type type)
		{
			return MetadataReference.CreateFromFile(type.GetTypeInfo().Assembly.Location);
		}
	}

    public class SourceCode
    {
		// todo: make not hacky
		public AssemblyLoadContext Accessor { get; set; }

		public ILibraryExporter LibraryExporter { get; set; }

        private Type _compiledType;
        private bool _isCompiled;


        public string Source { get; set; }

        public bool IsLegit()
        {
            // todo: figure out a way to parse for mis-behaving code...

            return _isCompiled == true && _compiledType != null;
        }

        private bool ValidateResult(object generatedClass)
        {
            // todo: figure out if the resultant object is a good citizen...

            return true;
        }

        public IEnumerable<RandomValues> GenerateData(int count)
        {

            if (IsLegit())
            {
                // this path isn't doing anything yet...
                var randomObjects = A.ListOf(_compiledType, count);

                // make sure there's nothing fishy about the generated type
                if (randomObjects.All(o => ValidateResult(o)))
                {
                    return randomObjects.Select(r => GetPropertyValues(r));
                }
            }

            return null;

        }

        public CompileResult Compile()
        {
            var result = new CompileResult();

            //var assemblyPath = Path.GetDirectoryName(typeof(object).GetTypeInfo().Assembly.Location);
            var assemblyName = Guid.NewGuid().ToString();

            this.Source = CleanSource(this.Source);

            var syntaxTrees = CSharpSyntaxTree.ParseText(this.Source);

			// build references up
			var references = new List<MetadataReference>();

			foreach (var type in SourceCodeHelpers.SupportedTypes)
			{
				references.Add(type.GetMeta());
			}

			//typeof(object).GetTypeInfo().Assembly.GetName().Name
			//var exports = LibraryExporter.GetExport("GenFu.Web");

			/*
			foreach (var export in exports)
			{
				//foreach (var reference in export.Library.Path) //.Where(r => r.Display == "System.Runtime")
				//{
				var path = export.Library.Path;

				MetadataReference reference = null;

				if (path != null)
				{
					reference = MetadataReference.CreateFromFile(path);
				}

				if (reference != null)
				{
					references.Add(reference);
				}


				//}

			}
			

			/*
            foreach (var reference in export.GetMetadataReferences().Where(r=> r.Display == "System.Runtime"))
            {
                references.Add(reference.ConvertMetadataReference(MetadataReferenceExtensions.CreateAssemblyMetadata));                
            }
			*/
			//MetadataReference.CreateFromFile(typeof(A).GetTypeInfo().Assembly.Location)
			// set up compilation
			var compilation = CSharpCompilation.Create(assemblyName)
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(references)
                .AddSyntaxTrees(syntaxTrees);
            
            // build the assembly
            Assembly assembly = null;

            using (var stream = new MemoryStream())
            {
                // this is broked...
                EmitResult compileResult = compilation.Emit(stream);
                // we get here, with diagnostic errors (check compileResult.Diagnostics)
                if (compileResult.Success)
                {
                    stream.Position = 0;
					//assembly = Accessor..Default.LoadStream(stream, null);
					assembly = Accessor.LoadFromStream(stream, null);
				}
                else
                {
                    result.IsValid = false;
                    result.Errors = compileResult.Diagnostics.Select(d => d.ToString());
                }

            }

            if (assembly != null)
            {
                // iterate over the types in the assembly
                var types = assembly.GetExportedTypes();
                if (types.Length == 1)
                {
                    _compiledType = types[0];
                    result.IsValid = true;
                }
                if (types.Length > 1)
                {
                    result.IsValid = false;
                    result.Errors = new[] { "We currently only support a single type through this website. Install GenFu in your own project to generate data for multiple types." };
                }
            }
            _isCompiled = result.IsValid;

            return result;
        }

        private string CleanSource(string source)
        {
            var newSource = new StringBuilder();

            // add some useful usings
            var usings = new List<string>
            {
                // for now, just the one?
                "using System;"
            };
            foreach (var useingthing in usings)
            {
                if ((CultureInfo.CurrentCulture.CompareInfo.IndexOf(source, useingthing, CompareOptions.IgnoreCase) < 0))
                    newSource.AppendLine(useingthing);
            }

            // add original source
            newSource.Append(source);

            return newSource.ToString();
        }

        private static RandomValues GetPropertyValues(object target)
        {
            var propertyMap = new RandomValues();

            try
            {
                var properties = target.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    try
                    {
                        var key = prop.Name;
                        var value = prop.GetValue(target).ToString();
                        propertyMap.Add(key, value);
                    }
                    catch
                    {
                        // following best practices and swallowing all exceptions :oP
                    }
                }
            }
            catch
            {
                // ...and release! i'm no fisherman
            }

            return propertyMap;
        }
    }
}