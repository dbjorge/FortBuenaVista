using NUnit.Framework;

namespace FortBuenaVista.DesktopApp.Test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void TravisCi_TrivialTest_Passes()
        {
            Assert.IsTrue(1 + 1 == 2);
        }
    }
}
