using Angela.Core;
using System;

namespace Angela.vNext.SampleConsole
{

    public class Person
    {
        public string FirstName { get; set; }

    }

    public class Program
    {
        public void Main(string[] args)
        {
            var person = A.New<Person>();
            Console.WriteLine(person.FirstName);
            Console.ReadLine();

            //var people = A.Few<Person>();
        }
    }
}
