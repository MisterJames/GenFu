using System.Collections.Generic;
using Angela.Core;
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
            IList<Person> peeps = Angie.FastList<Person>(10);

            Angie.Default().ListCount(25);

            IList<Dog> dogs = Angie.Configure<Dog>().Fill(d => d.Owner).WithRandom(peeps).MakeList();
            foreach (Dog dog in dogs)
            {
                Assert.IsNotNull(dog.Owner);
                CollectionAssert.Contains(peeps, dog.Owner);
            }
        }
    }
}
