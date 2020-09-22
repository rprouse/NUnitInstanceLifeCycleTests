using System.Runtime.Serialization;
using NUnit.Framework;

namespace NUnitInstanceLifeCycleTests
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(ParallelScope.All)]
    public class ParallelConstructorTests
    {
        static ObjectIDGenerator generator = new ObjectIDGenerator();
        int i = 0;

        public ParallelConstructorTests()
        {
            OutputReferenceId("Constructor");
            i++;
        }

        [Test]
        public void TestOne()
        {
            OutputReferenceId("TestOne");
            Assert.That(i, Is.EqualTo(1));
            i++;
        }

        [Test]
        public void TestTwo()
        {
            OutputReferenceId("TestTwo");
            Assert.That(i, Is.EqualTo(1));
            i++;
        }

        [Test]
        public void TestThree()
        {
            OutputReferenceId("TestThree");
            Assert.That(i, Is.EqualTo(1));
            i++;
        }

        private void OutputReferenceId(string location)
        {
            long id = generator.GetId(this, out bool first);
            TestContext.WriteLine($"{location}: {id} is first <{first}>");
        }
    }
}
