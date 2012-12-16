using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angela.Tests
{
    internal class Person
    {
        // firstname FirstName fname first_name
        public string FirstName { get; set; }

        // lastname LastName lname last_name
        public string LastName { get; set; }

        // word
        public string Title { get; set; }

        // age
        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        public int NumberOfKids { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }
    }
}
