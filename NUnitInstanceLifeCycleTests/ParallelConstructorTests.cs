using System.Runtime.Serialization;
using NUnit.Framework;

namespace NUnitInstanceLifeCycleTests
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(ParallelScope.All)]
    public class ParallelConstructorTests
    {
        int constructorCount = 0;
        int setupCount = 0;

        public ParallelConstructorTests()
        {
            constructorCount++;
        }

        [SetUp]
        public void SetUp()
        {
            setupCount++;
        }

        [Test]
        public void EnsureParallelTestsRunInNewInstance1()
        {
            Assert.That(constructorCount, Is.EqualTo(1));
            Assert.That(setupCount, Is.EqualTo(1));
        }

        [Test]
        public void EnsureParallelTestsRunInNewInstance2()
        {
            Assert.That(constructorCount, Is.EqualTo(1));
            Assert.That(setupCount, Is.EqualTo(1));
        }

        [Test]
        public void EnsureParallelTestsRunInNewInstance3()
        {
            Assert.That(constructorCount, Is.EqualTo(1));
            Assert.That(setupCount, Is.EqualTo(1));
        }
    }
}
