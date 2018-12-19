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
            Parallel.For(0, 10000, i =>
            {
                A.New<Profile>();
            });
        }

        [Fact]
        public void registrations_can_be_reset()
        {
            Parallel.For(0, 10000, i =>
               {
                   A.New<Profile>();
                   A.Reset();
               });
        }

        [Fact]
        public void registrations_can_be_reset_separatelly()
        {
            Parallel.For(0, 10000, i =>
            {
                A.New<Profile>();
                A.New<Person>();
                A.Reset<Profile>();
                A.Reset();
            });
        }

        [Fact]
        public void registrations_are_configurable()
        {

            Parallel.For(0, 10000, i =>
            {
                A.Configure<Person>().Fill(x => x.Age).WithinRange(20, 30);
                var person = A.New<Person>();

                //There is a race condition here:
                // --> if some other test does a Reset o register a new rule this condition will not be met. Thankfully maxParallelThreads is 1
                Assert.True(person.Age >= 20 && person.Age <= 30);
            });

            Parallel.For(0, 10000, i =>
            {
                A.Configure<Person>().Fill(x => x.Age).WithinRange(40, 50);
                var person = A.New<Person>();

                Assert.True(person.Age >= 40 && person.Age <= 50);
            });
        }
    }
}