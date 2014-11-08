using System;

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
    }
}