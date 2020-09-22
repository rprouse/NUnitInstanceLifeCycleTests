using System.Runtime.Serialization;
using NUnit.Framework;

namespace NUnitInstanceLifeCycleTests
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(ParallelScope.All)]
    public class ParallelSetupTests
    {
        static ObjectIDGenerator generator = new ObjectIDGenerator();
        int i = 0;

        [SetUp]
        public void SetUp()
        {
            OutputReferenceId("SetUp");
            i++;
        }

        [Test]
        public void TestOne()
        {
            OutputReferenceId("TestOne");
            Assert.That(i, Is.EqualTo(1));
        }

        [Test]
        public void TestTwo()
        {
            OutputReferenceId("TestTwo");
            Assert.That(i, Is.EqualTo(1));
        }

        [Test]
        public void TestThree()
        {
            OutputReferenceId("TestThree");
            Assert.That(i, Is.EqualTo(1));
        }

        private void OutputReferenceId(string location)
        {
            long id = generator.GetId(this, out bool first);
            TestContext.WriteLine($"{location}: {id} is first <{first}>");
        }
    }
}
