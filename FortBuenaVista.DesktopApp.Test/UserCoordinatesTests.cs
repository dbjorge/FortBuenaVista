using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FortBuenaVista.DesktopApp.Test
{
    [TestFixture]
    class UserCoordinatesTests
    {
        [Test]
        public void NearestNHardpoints_N1_Returns1Hardpoint()
        {
            var uc = new UserCoordinates() {HardpointCoordinates = new PointF(0, 0)};
            Assert.AreEqual(1, uc.NearestNHardpoints(1).Count);
        }

        [Test]
        public void NearestNHardpoints_N5_Returns5Hardpoints()
        {
            var uc = new UserCoordinates() { HardpointCoordinates = new PointF(0, 0) };
            Assert.AreEqual(5, uc.NearestNHardpoints(5).Count);
        }

        // Geometry-wise, .5 away is where the correct result stops being the origin point
        [Test]
        [TestCase(-.449f, -.449f)]
        [TestCase(-.449f, 0)]
        [TestCase(-.449f, .449f)]
        [TestCase(0, -.449f)]
        [TestCase(0, 0)]
        [TestCase(0, .449f)]
        [TestCase(.449f, -.449f)]
        [TestCase(.449f, 0)]
        [TestCase(.449f, .449f)]
        public void NearestNHardpoints_N1NearOrigin_ReturnsOriginHardpoint(float x, float y)
        {
            var uc = new UserCoordinates() {HardpointCoordinates = new PointF(x, y)};
            Assert.AreEqual(new Hardpoint(0, 0, 0), uc.NearestNHardpoints(1).First());
        }

        // Geometry-wise, .5 away is where the correct result stops being the origin point
        [Test]
        [TestCase(-.449f, -.449f)]
        [TestCase(-.449f, 0)]
        [TestCase(-.449f, .449f)]
        [TestCase(0, -.449f)]
        [TestCase(0, 0)]
        [TestCase(0, .449f)]
        [TestCase(.449f, -.449f)]
        [TestCase(.449f, 0)]
        [TestCase(.449f, .449f)]
        public void NearestHardpoint_NearOrigin_ReturnsOriginHardpoint(float x, float y)
        {
            var uc = new UserCoordinates() { HardpointCoordinates = new PointF(x, y) };
            Assert.AreEqual(new Hardpoint(0, 0, 0), uc.NearestHardpoint());
        }

        // Geometry-wise, (1/6,1/6) is the point at which (0,-1) and (1,1) are equidistant
        [Test]
        [TestCase(.167f, .167f)]
        [TestCase(.167f, .5f)]
        [TestCase(.167f, .833f)]
        [TestCase(.5f, .167f)]
        [TestCase(.5f, .5f)]
        [TestCase(.5f, .833f)]
        [TestCase(.833f, .167f)]
        [TestCase(.833f, .5f)]
        [TestCase(.833f, .833f)]
        public void NearestNHardpoints_N4NearCenterOfGridSquare_ReturnsGridCorners(float x, float y)
        {
            var uc = new UserCoordinates() { HardpointCoordinates = new PointF(x, y) };
            var actual = uc.NearestNHardpoints(4).ToList();
            foreach (var expectedHardpoint in new[]
            {
                new Hardpoint(0, 0, 0),
                new Hardpoint(0, 1, 0),
                new Hardpoint(1, 0, 0),
                new Hardpoint(1, 1, 0)
            })
            {
                Assert.Contains(expectedHardpoint, actual);
            }
        }

        // Geometry-wise, .25 away from the origin is where the correct results stop being the
        // 3x3 centered at 0,0, since dist((.25,.25),(0,2)) == dist((.25,.25),(-1,-1)).
        [Test]
        [TestCase(-.249f, -.249f)]
        [TestCase(-.249f, 0)]
        [TestCase(-.249f, .249f)]
        [TestCase(0, -.249f)]
        [TestCase(0, 0)]
        [TestCase(0, .249f)]
        [TestCase(.249f, -.249f)]
        [TestCase(.249f, 0)]
        [TestCase(.249f, .249f)]
        public void NearestNHardpoints_N9AtLocationNearOrigin_ReturnsHardpointsAroundOrigin(float x, float y)
        {
            var uc = new UserCoordinates() { HardpointCoordinates = new PointF(x, y) };
            var actual = uc.NearestNHardpoints(9).ToList();
            foreach (var expectedHardpoint in new[]
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
            })
            {
                Assert.Contains(expectedHardpoint, actual);
            }
        }

        [Test]
        public void NearestNHardpoints_N4AtUnambiguousPoint_ReturnsHardpointsInDistanceOrder()
        {
            var uc = new UserCoordinates() { HardpointCoordinates = new PointF(.6f, .7f) };
            var actual = uc.NearestNHardpoints(4);

            Assert.AreEqual(new Hardpoint(1, 1, 0), actual[0]);
            Assert.AreEqual(new Hardpoint(0, 1, 0), actual[1]);
            Assert.AreEqual(new Hardpoint(1, 0, 0), actual[2]);
            Assert.AreEqual(new Hardpoint(0, 0, 0), actual[3]);
        }
    }
}
