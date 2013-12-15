using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace FortBuenaVista.DesktopApp.Test
{
    public class MockFortressComponent : IFortressComponent
    {
        public Position Position { get; set; }
        public FoundationComponentType ComponentType { get; set; }
    }

    [TestFixture]
    public class FortressLayoutTests
    {
        private static IFortressComponent MakeTestComponentAt(int x, int y, int z)
        {
            var testHardpoint = new Hardpoint(x, y);
            var testComponent = new MockFortressComponent()
            {
                Position = new Position(new Hardpoint[] { testHardpoint }, z),
                ComponentType = FoundationComponentType.Else
            };
            return testComponent;
        }

        [Test]
        public void Add_AppendsToComponents()
        {
            var fl = new FortressLayout();
            var component = MakeTestComponentAt(0, 0, 0);
            fl.Add(component);

            Assert.AreEqual(1, fl.ComponentsByZOrder.ToList().Count);
            Assert.AreSame(component, fl.ComponentsByZOrder.First());
        }

        [Test]
        public void EnumerableConstructor_AppendsToComponents()
        {
            var component = MakeTestComponentAt(0, 0, 0);
            var fl = new FortressLayout(new IFortressComponent[] { component });

            Assert.AreEqual(1, fl.ComponentsByZOrder.ToList().Count);
            Assert.AreSame(component, fl.ComponentsByZOrder.First());
        }

        [Test]
        public void ComponentsByHardpoint_OneHardpointAdded_ReturnsListOfIt()
        {
            var component = MakeTestComponentAt(0, 0, 0);
            var fl = new FortressLayout(new IFortressComponent[] { component });

            Assert.AreEqual(1, fl.ComponentsByHardpoint(new Hardpoint(0, 0)).ToList().Count);
        }

        [Test]
        public void ComponentsByHardpoint_NoMatchingHardpointAdded_ReturnsEmptyList()
        {
            var testHardpoint = new Hardpoint(0, 0);
            var component = new MockFortressComponent()
            {
                Position = new Position(new Hardpoint[] { testHardpoint }, 0),
                ComponentType = FoundationComponentType.Else
            };
            var fl = new FortressLayout(new IFortressComponent[] { component });

            Assert.IsEmpty(fl.ComponentsByHardpoint(new Hardpoint(27, 27)));
        }

        [Test]
        public void ComponentsByHardpoint_SeveralMatchingHardpointsAdded_ReturnsAll()
        {
            var fl = new FortressLayout(new IFortressComponent[]
            {
                MakeTestComponentAt(0, 0, 0),
                MakeTestComponentAt(0, 0, 0),
                MakeTestComponentAt(0, 0, 1)
            });

            Assert.AreEqual(3, fl.ComponentsByHardpoint(new Hardpoint(0, 0)).ToList().Count);
        }
    }
}
