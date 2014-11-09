using Microsoft.AspNet.Mvc.Razor;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace GenFu.Web.Models
{
    public class SourceCode
    {
        public string Source { get; set; }

        public bool IsLegit()
        {
            // todo: figure out a way to parse for mis-behaving code...

            return true;
        }

        private bool ValidateResult(object generatedClass)
        {
            // todo: figure out if the resultant object is a good citizen...

            return true;
        }

        public object Process()
        {

            if (IsLegit())
            {
                var type = BuildType();
                var result = A.New(type);

                // make sure there's nothing fishy about the generated type
                if (ValidateResult(result))
                {
                    return result;
                }
            }

            return null;

        }

        private Type BuildType()
        {
            var assemblyPath = Path.GetDirectoryName(typeof(object).Assembly.Location);
            var assemblyName = Guid.NewGuid().ToString();
            var syntaxTrees = CSharpSyntaxTree.ParseText(this.Source);

            // build references up
            var references = new List<MetadataReference>();
            references.Add(MetadataReference.CreateFromAssembly(typeof(object).GetTypeInfo().Assembly));

            // set up compilation
            var compilation = CSharpCompilation.Create(assemblyName)
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(references)
                .AddSyntaxTrees(syntaxTrees);

            // build the assembly
            Assembly assembly;
            using (var stream = new MemoryStream())
            {
                var compileResult = compilation.Emit(stream);
                assembly = Assembly.Load(stream.GetBuffer());
            }

            // iterate over the types in the assembly
            var types = assembly.GetExportedTypes();
            if (types.Length == 1)
            {
                return types[0];
            }
            if (types.Length > 1)
            {
                // do something interesting, perhaps with the BadSourceCode class?
            }

            return null;
        }

        public static Dictionary<string, string> GetPropertyValues(object target)
        {
            var propertyMap = new Dictionary<string, string>();

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