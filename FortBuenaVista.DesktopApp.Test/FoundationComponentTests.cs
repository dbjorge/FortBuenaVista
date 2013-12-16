using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FortBuenaVista.DesktopApp.Test
{
    [TestFixture]
    class FoundationComponentTests
    {
        [Test]
        public void FromCenterPoint_AddsCorrectHardpointGrid()
        {
            var foundation = FoundationComponent.AtCenterPoint(new Hardpoint(0, 0, 0));
            Assert.AreEqual(9, foundation.Position.Hardpoints.Count);
            Assert.IsTrue(foundation.Position.Hardpoints.Contains(new Hardpoint(-1, -1, 0)));
            Assert.IsTrue(foundation.Position.Hardpoints.Contains(new Hardpoint(-1, 0, 0)));
            Assert.IsTrue(foundation.Position.Hardpoints.Contains(new Hardpoint(-1, 1, 0)));
            Assert.IsTrue(foundation.Position.Hardpoints.Contains(new Hardpoint(0, -1, 0)));
            Assert.IsTrue(foundation.Position.Hardpoints.Contains(new Hardpoint(0, 0, 0)));
            Assert.IsTrue(foundation.Position.Hardpoints.Contains(new Hardpoint(0, 1, 0)));
            Assert.IsTrue(foundation.Position.Hardpoints.Contains(new Hardpoint(1, -1, 0)));
            Assert.IsTrue(foundation.Position.Hardpoints.Contains(new Hardpoint(1, 0, 0)));
            Assert.IsTrue(foundation.Position.Hardpoints.Contains(new Hardpoint(1, 1, 0)));
        }

        [Test]
        public void FromCenterPoint_ZLevelIsZero()
        {
            var foundation = FoundationComponent.AtCenterPoint(new Hardpoint(0, 0, 0));
            Assert.AreEqual(0, foundation.Position.ZLevel);
        }

        [Test]
        public void FromCenterPoint_ComponentTypeIsFloor()
        {
            var foundation = FoundationComponent.AtCenterPoint(new Hardpoint(0, 0, 0));
            Assert.AreEqual(FoundationComponentType.Floor, foundation.ComponentType);
        }

        [Test]
        public void CalculateBoundingBox_SortedInput_CalculatesCorrectCorner()
        {
            var foundation = FoundationComponent.AtCenterPoint(new Hardpoint(0, 0, 0));
            var testHardpoints = new[]
            {
                new Hardpoint(-1, -1, 0),
                new Hardpoint(-1, 0, 0),
                new Hardpoint(-1, 1, 0),
                new Hardpoint(0, -1, 0),
                new Hardpoint(0, 0, 0),
                new Hardpoint(0, 1, 0),
                new Hardpoint(1, -1, 0),
                new Hardpoint(1, 0, 0),
                new Hardpoint(1, 1, 0)
            };

            var actual = foundation.CalculateBoundingBox(new Position(testHardpoints));
            Assert.AreEqual(-1, actual.Left, .00001);
            Assert.AreEqual(-1, actual.Top, .00001);
        }

        [Test]
        public void CalculateBoundingBox_UnsortedInput_CalculatesCorrectCorner()
        {
            var foundation = FoundationComponent.AtCenterPoint(new Hardpoint(0, 0, 0));
            var testHardpoints = new[]
            {
                new Hardpoint(0, 0, 0),
                new Hardpoint(-1, 0, 0),
                new Hardpoint(1, 1, 0),
                new Hardpoint(-1, 1, 0),
                new Hardpoint(1, -1, 0),
                new Hardpoint(0, 1, 0),
                new Hardpoint(0, -1, 0),
                new Hardpoint(-1, -1, 0),    
                new Hardpoint(1, 0, 0)
            };

            var actual = foundation.CalculateBoundingBox(new Position(testHardpoints));
            Assert.AreEqual(-1, actual.Left, .00001);
            Assert.AreEqual(-1, actual.Top, .00001);
        }

        [Test]
        public void CalculateBoundingBox_UnsortedInput_CalculatesCorrectSize()
        {
            var foundation = FoundationComponent.AtCenterPoint(new Hardpoint(0, 0, 0));
            var testHardpoints = new Hardpoint[]
            {
                new Hardpoint(-1, -1, 0),
                new Hardpoint(-1, 0, 0),
                new Hardpoint(-1, 1, 0),
                new Hardpoint(0, -1, 0),
                new Hardpoint(0, 0, 0),
                new Hardpoint(0, 1, 0),
                new Hardpoint(1, -1, 0),
                new Hardpoint(1, 0, 0),
                new Hardpoint(1, 1, 0)
            };

            var actual = foundation.CalculateBoundingBox(new Position(testHardpoints));
            Assert.AreEqual(2, actual.Width, .00001);
            Assert.AreEqual(2, actual.Height, .00001);
        }
    }
}
