namespace GenFu.Web.Models;

using System.Collections.Generic;

public class GenerateDataModel
{
    public string Source { get; set; }

    public bool HasCompileErrors { get; set; }

    public IEnumerable<string> CompileErrors { get; set; }

    public IEnumerable<RandomValues> RandomObjects { get; set; }

    public IEnumerable<string> PropertyNames { get; set; }

}
