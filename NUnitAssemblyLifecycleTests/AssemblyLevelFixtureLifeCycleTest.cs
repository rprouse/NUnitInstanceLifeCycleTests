using NUnit.Framework;

[assembly: FixtureLifeCycle(LifeCycle.InstancePerTestCase)]

[TestFixture]
public class AssemblyLevelFixtureLifeCycleTest
{
    private int _value;

    [Test]
    public void Test1() => Assert.AreEqual(0, _value++);

    [Test]
    public void Test2() => Assert.AreEqual(0, _value++);
}