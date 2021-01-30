using NUnit.Framework;

namespace NUnitInstanceLifeCycleTests
{
    [TestFixtureSource(nameof(FixtureArgs))]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class LifeCycleWithTestFixtureSourceTest
    {
        private readonly int _initialValue;
        private int _value;

        public LifeCycleWithTestFixtureSourceTest(int num)
        {
            _initialValue = num;
            _value = num;
        }

        public static int[] FixtureArgs() => new[] { 1, 42 };

        [Test]
        public void Test1() => Assert.AreEqual(_initialValue, _value++);

        [Test]
        public void Test2() => Assert.AreEqual(_initialValue, _value++);
    }
}
