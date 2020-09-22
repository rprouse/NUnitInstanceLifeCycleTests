using System;
using System.Runtime.Serialization;
using NUnit.Framework;

namespace NUnitInstanceLifeCycleTests
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class OneTimeSetupTests
    {
        static ObjectIDGenerator generator = new ObjectIDGenerator();
        static int oneTimeSetupCount = 0;
        static int oneTimeTeardownCount = 0;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            Console.WriteLine("OneTimeSetUp");
            oneTimeSetupCount++;
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            Console.WriteLine("OneTimeTearDown");
            oneTimeTeardownCount++;
        }

        [Test]
        public void TestOne()
        {
            OutputReferenceId("TestOne");
            Assert.That(oneTimeSetupCount, Is.EqualTo(1));
            Assert.That(oneTimeTeardownCount, Is.EqualTo(0));
        }

        [Test]
        public void TestTwo()
        {
            OutputReferenceId("TestTwo");
            Assert.That(oneTimeSetupCount, Is.EqualTo(1));
            Assert.That(oneTimeTeardownCount, Is.EqualTo(0));
        }

        [Test]
        public void TestThree()
        {
            OutputReferenceId("TestThree");
            Assert.That(oneTimeSetupCount, Is.EqualTo(1));
            Assert.That(oneTimeTeardownCount, Is.EqualTo(0));
        }

        private void OutputReferenceId(string location)
        {
            long id = generator.GetId(this, out bool first);
            TestContext.WriteLine($"{location}: {id} is first <{first}>");
        }
    }
}
