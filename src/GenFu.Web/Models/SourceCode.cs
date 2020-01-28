using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Runtime.Loader;
using GenFu.Web.Helpers;
using Microsoft.CodeAnalysis.CSharp;

namespace GenFu.Web.Models
{
    public class SourceCode
    {
		public SourceCode()
		{
			//Check to see if we need to compute Metadata References
			// build references up
			if (references == null || references.Count == 0)
			{
				foreach (var type in SourceCodeHelpers.SupportedTypes)
				{
					references.Add(type.GetMeta());
				}

				//compare to see if we got duplicate data
				var noDuplicatesList = references.GroupBy(x => x.Display).Select(x => x.First()).ToList();

				references.Clear();

				references.AddRange(noDuplicatesList);
			}


		}

		// todo: make not hacky
		public AssemblyLoadContext Accessor { get; set; }

		//cache meta data, these bits are costly to load and can cause frequent GC
		//also since we have a hard coded list there's no need to recompute this per request
		private static readonly List<MetadataReference> references = new List<MetadataReference>();

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