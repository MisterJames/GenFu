using Angela.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Angie
                .Configure()
                .ListCount(8)
                .MakeList<Person>();

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }

            Console.ReadLine();
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return string.Format("You can reach {0} {1} at \n\te:{2}\n\tp:{3}\n", FirstName, LastName, Email, PhoneNumber);
        }
        
    }

}
