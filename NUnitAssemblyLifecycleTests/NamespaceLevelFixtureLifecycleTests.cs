using NUnit.Framework;

namespace NUnitAssemblyLifecycleTests
{
    [TestFixture]
    public class NamespaceLevelFixtureLifecycleTests
    {
        private int _value;

        [Test]
        public void Test1() => Assert.AreEqual(0, _value++);

        [Test]
        public void Test2() => Assert.AreEqual(0, _value++);
    }
}
