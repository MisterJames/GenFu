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



        [Fact]
        public void registration_changes_are_non_deterministic()
        {
            /*
             * this is not exactly a test
             * we demosntrate here that, while the FillerManager is thread safe, 
             * it is not deterministic for multithreading
             * because we have only one shared storage
             */
            /*
             * THIS TEST CAN BE SAFELY DELETED 
             */

            var testOneGreaterThan100 = false;
            var testOneSmallerThan100 = false;
            var testTwoGreaterThan100 = false;
            var testTwoSmallerThan100 = false;

            Parallel.For(0, 1000, i =>
            {
                //conf #1
                A.Configure<Person>().Fill(x => x.Id).WithinRange(200, 300);

                var one = A.New<Person>();
                testOneGreaterThan100 = testOneGreaterThan100 || one.Id > 100; //comes from conf#1 in any thread
                testOneSmallerThan100 = testOneSmallerThan100 || one.Id < 100; //comes from conf#2 in another thread

                //conf #2
                A.Configure<Person>().Fill(x => x.Id).WithinRange(20, 30);

                var two = A.New<Person>();
                testTwoGreaterThan100 = testTwoGreaterThan100 || two.Id > 100; //comes from conf#1 in any thread
                testTwoSmallerThan100 = testTwoSmallerThan100 || two.Id < 100; //comes from conf#2 in another thread
            });

            //if it were ran in a single thread both assertions would fail
            Assert.True(testOneGreaterThan100 && testOneSmallerThan100); //result is not deterministic 
            Assert.True(testTwoGreaterThan100 && testTwoSmallerThan100); //result is not deterministic 
        }
    }
}