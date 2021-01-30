using NUnit.Framework;

namespace NUnitInstanceLifeCycleTests
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class FixtureWithTestCases
    {
        private int _counter;

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Test(int _)
        {
            Assert.AreEqual(0, _counter++);
        }
    }
}
