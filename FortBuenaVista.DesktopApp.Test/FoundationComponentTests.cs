using System;
using System.Collections.Generic;
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
            var foundation = FoundationComponent.FromCenterPoint(new Hardpoint(0, 0));
            Assert.AreEqual(9, foundation.Position.Hardpoints.Count);
            Assert.IsTrue(foundation.Position.Hardpoints.Contains(new Hardpoint(-1, -1)));
            Assert.IsTrue(foundation.Position.Hardpoints.Contains(new Hardpoint(-1,  0)));
            Assert.IsTrue(foundation.Position.Hardpoints.Contains(new Hardpoint(-1,  1)));
            Assert.IsTrue(foundation.Position.Hardpoints.Contains(new Hardpoint( 0, -1)));
            Assert.IsTrue(foundation.Position.Hardpoints.Contains(new Hardpoint( 0,  0)));
            Assert.IsTrue(foundation.Position.Hardpoints.Contains(new Hardpoint( 0,  1)));
            Assert.IsTrue(foundation.Position.Hardpoints.Contains(new Hardpoint( 1, -1)));
            Assert.IsTrue(foundation.Position.Hardpoints.Contains(new Hardpoint( 1,  0)));
            Assert.IsTrue(foundation.Position.Hardpoints.Contains(new Hardpoint( 1,  1)));
        }

        [Test]
        public void FromCenterPoint_ZLevelIsZero()
        {
            var foundation = FoundationComponent.FromCenterPoint(new Hardpoint(0, 0));
            Assert.AreEqual(0, foundation.Position.ZLevel);
        }

        [Test]
        public void FromCenterPoint_ComponentTypeIsFloor()
        {
            var foundation = FoundationComponent.FromCenterPoint(new Hardpoint(0, 0));
            Assert.AreEqual(FoundationComponentType.Floor, foundation.ComponentType);
        }
    }
}
