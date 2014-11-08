using System;
using System.Collections.Generic;

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