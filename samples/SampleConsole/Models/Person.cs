using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsole.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return string.Format("You can reach {0} {1} (age {2}) at \n\te:{3}\n\tp:{4}\n", FirstName, LastName, Age, Email, PhoneNumber);
        }

    }
}
