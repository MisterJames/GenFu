using Angela.Core;
using System;

namespace Angela.vNext.SampleConsole
{

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string EmailAddress { get; set; }

    }

    public class Program
    {
        public void Main(string[] args)
        {
            var person =  A.New<Person>();
            Console.WriteLine(person.FirstName);

            A.Configure<Person>()
                //.Fill(p => p.FirstName).WithRandom(new string[] { "James", "David" })
                .Fill(p => p.Age).WithinRange(19, 25);

            var people = A.ListOf<Person>();

            foreach (var p in people)
            {
                Console.WriteLine(string.Format("{0} is {1} years old", p.FirstName, p.Age));
            }

            Console.ReadLine();
        }
    }
}
