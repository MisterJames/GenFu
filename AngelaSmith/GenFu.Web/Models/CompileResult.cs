using System;
using System.Collections.Generic;

namespace GenFu.Web.Models
{
    public class CompileResult
    {
        public bool IsValid { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}