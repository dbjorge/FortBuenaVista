using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace FortBuenaVista.DesktopApp.Test
{
    public class MockFortressComponent : IFortressComponent
    {
        public Position Position { get; set; }
        public RectangleF BoundingBox { get { return new RectangleF(27, 27, 2, 2); } }
        public Color FillColor { get { return Color.Black; } }
        public FoundationComponentType ComponentType { get; set; }
    }

    [TestFixture]
    public class FortressLayoutTests
    {
        private static IFortressComponent MakeTestComponentAt(int x, int y, int z)
        {
            var testHardpoint = new Hardpoint(x, y, z);
            var testComponent = new MockFortressComponent()
            {
                Position = Position.OneByOneAt(testHardpoint),
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
            var fl = new FortressLayout(new[] { component });

            Assert.AreEqual(1, fl.ComponentsByZOrder.ToList().Count);
            Assert.AreSame(component, fl.ComponentsByZOrder.First());
        }

        [Test]
        public void ComponentsByHardpoint_OneHardpointAdded_ReturnsListOfIt()
        {
            var component = MakeTestComponentAt(0, 0, 0);
            var fl = new FortressLayout(new[] { component });

            Assert.AreEqual(1, fl.ComponentsByHardpoint(new Hardpoint(0, 0, 0)).ToList().Count);
        }

        [Test]
        public void ComponentsByHardpoint_NoMatchingHardpointAdded_ReturnsEmptyList()
        {
            var component = MakeTestComponentAt(0, 0, 0);
            var fl = new FortressLayout(new[] { component });

            Assert.IsEmpty(fl.ComponentsByHardpoint(new Hardpoint(27, 27, 0)));
        }

        [Test]
        public void ComponentsByHardpoint_AllMatchingHardpointsAdded_ReturnsAll()
        {
            var fl = new FortressLayout(new[]
            {
                MakeTestComponentAt(0, 0, 0),
                MakeTestComponentAt(0, 0, 0),
                MakeTestComponentAt(0, 0, 0)
            });

            Assert.AreEqual(3, fl.ComponentsByHardpoint(new Hardpoint(0, 0, 0)).ToList().Count);
        }

        [Test]
        public void ComponentsByHardpoint_SomeMatchingHardpointsAdded_ReturnsOnlyMatches()
        {
            var fl = new FortressLayout(new[]
            {
                MakeTestComponentAt(0, 0, 0),
                MakeTestComponentAt(0, 0, 2),
                MakeTestComponentAt(0, 0, 0)
            });

            Assert.AreEqual(2, fl.ComponentsByHardpoint(new Hardpoint(0, 0, 0)).ToList().Count);
            Assert.AreEqual(1, fl.ComponentsByHardpoint(new Hardpoint(0, 0, 2)).ToList().Count);
        }
    }
}
