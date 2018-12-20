using System;
using System.Threading.Tasks;
using GenFu.Tests.TestEntities;
using Xunit;

namespace GenFu.Tests
{
    public class When_running_in_parallel
    {
        [Fact]
        public void new_instances_are_issued()
        {
            var genfu = new GenFuInstance();
            Parallel.For(0, 10000, i =>
            {
                genfu.New<Profile>();
            });
        }

        [Fact]
        public void registrations_can_be_reset()
        {
            var genfu = new GenFuInstance();
            Parallel.For(0, 10000, i =>
               {
                   genfu.New<Profile>();
                   genfu.Reset();
               });
        }

        [Fact]
        public void registrations_can_be_reset_separatelly()
        {
            var genfu = new GenFuInstance();
            Parallel.For(0, 10000, i =>
            {
                genfu.New<Profile>();
                genfu.New<Person>();
                genfu.Reset<Profile>();
                genfu.Reset();
            });
        }

        [Fact]
        public void registrations_are_configurable()
        {
            var genfu = new GenFuInstance();
            Parallel.For(0, 10000, i =>
            {
                genfu.Configure<Person>().Fill(x => x.Age).WithinRange(20, 30);
                var person = genfu.New<Person>();

                Assert.True(person.Age >= 20 && person.Age <= 30);
            });

            Parallel.For(0, 10000, i =>
            {
                genfu.Configure<Person>().Fill(x => x.Age).WithinRange(40, 50);
                var person = genfu.New<Person>();

                Assert.True(person.Age >= 40 && person.Age <= 50);
            });
        }

        [Fact]
        public void genfu_instances_dont_interfere_each_other()
        {
            var childGenerator = new GenFuInstance();
            var youngGenerator = new GenFuInstance();

            A.Configure<Person>().Fill(x => x.Age, () => 95); //Old style global reference
            childGenerator.Configure<Person>().Fill(x => x.Age, () => 10); //instance #1
            youngGenerator.Configure<Person>().Fill(x => x.Age, () => 20); //instance #2

            var childAge = 0;
            var youngAge = 0;
            var oldAge = 0;

            Parallel.For(0, 1000, i =>
            {
                var aged = A.New<Person>();
                var child = childGenerator.New<Person>();
                var young = youngGenerator.New<Person>();
                childAge = Math.Max(child.Age, childAge);
                youngAge = Math.Max(young.Age, youngAge);
                oldAge = Math.Max(aged.Age, oldAge);
            });

            Assert.True(childAge == 10);
            Assert.True(youngAge == 20);
            Assert.True(oldAge == 95);
        }
    }
}