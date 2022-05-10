namespace GenFu.Web.Models;

using System.Collections.Generic;

public class CompileResult
{
    public bool IsValid { get; set; }

    public IEnumerable<string> Errors { get; set; }
}
