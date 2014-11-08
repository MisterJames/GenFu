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

        private bool ValidateResult(object generatedClass)
        {
            // todo: figure out if the resultant object is a good citizen...

            return true;
        }

        public object Process()
        {

            if (IsLegit())
            {
                // here we'd actually compile the code
                var result = A.New<Person>();

                // make sure there's nothing fishy about the generated type
                if (ValidateResult(result))
                {
                    return result;
                }
            }

            return null;

        }
}