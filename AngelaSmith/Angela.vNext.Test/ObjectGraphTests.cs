using System.Collections.Generic;
using GenFu;
using NUnit.Framework;

namespace Angela.Tests
{
    [TestFixture]
    public class ObjectGraphTests
    {
        private class Dog
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }

        [Test]
        public void FillPropertyWithRandomValuesFromList()
        {
            IList<Person> peeps = A.ListOf<Person>(10);

            A.Default().ListCount(25);

            A.Configure<Dog>().Fill(d => d.Owner).WithRandom(peeps);

            var dogs = A.ListOf<Dog>();
            foreach (Dog dog in dogs)
            {
                Assert.IsNotNull(dog.Owner);
                CollectionAssert.Contains(peeps, dog.Owner);
            }
        }
    }
}
