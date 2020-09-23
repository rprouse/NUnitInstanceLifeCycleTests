using NUnit.Framework;

namespace NUnitInstanceLifeCycleTests
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class RepeatTests
    {        
        public int Counter { get; set; }

        public static int RepeatCounter { get; set; }

        [Test]
        [Repeat(3)]
        public void CounterShouldAlwaysStartAsZero()
        {
            Counter++;
            RepeatCounter++;
            Assert.That(Counter, Is.EqualTo(1));
        }
    }
}
