using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace FortBuenaVista.DesktopApp.Test
{
    public class MockFortressComponent : IFortressComponent
    {
        public ZOrder ZOrder { get; set; }
    }
    [TestFixture]
    public class FortressLayoutTests
    {
        [Test]
        public void Add_AppendsToComponents()
        {
            var fl = new FortressLayout();
            var component = new MockFortressComponent() {ZOrder = new ZOrder(27)};
            fl.Add(component);

            Assert.AreEqual(1, fl.Components.ToList().Count);
            Assert.AreSame(component, fl.Components.First());
        }

        [Test]
        public void EnumerableConstructor_AppendsToComponents()
        {
            
            var component = new MockFortressComponent() { ZOrder = new ZOrder(27) };
            var fl = new FortressLayout(new IFortressComponent[] { component });

            Assert.AreEqual(1, fl.Components.ToList().Count);
            Assert.AreSame(component, fl.Components.First());
        }
    }
}
