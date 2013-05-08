using Angela.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angela.Core.ValueGenerators.People;

namespace Angela.Tests.EF
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void UserListIsPopulated()
        {
            var users = new List<User>();
            Angie.Configure<User>().MakeList().ForEach(x => users.Add(x));
            Assert.IsTrue(users.Count > 0);
        }

        [Test]
        public void UserNameIsPopulated()
        {
            var users = new List<User>();
            Angie.Configure<User>().Fill(x => x.Name, () => Names.FullName()).MakeList().ForEach(x => users.Add(x));
            foreach (var user in users)
                Assert.IsTrue(user.Name.Split(' ').Count() > 1);
        }


        [Test]
        public void IdIsPopulated()
        {
            var user = Angie.Configure<User>().Make();
            Assert.IsNotNull(user.Id);
        }
    }
}
