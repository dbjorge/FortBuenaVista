using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FortBuenaVista.DesktopApp
{
    // Represents a user's mouse/touch position in Hardpoint coordinates
    public class UserCoordinates
    {
        public PointF HardpointCoordinates { get; set; }
        public int ZLevel { get; set; }

        // Functionally equivalent to NearestNHardpoints(1).First(), but more performant
        // since it doesn't need a temporary collection
        public Hardpoint NearestHardpoint()
        {
            return new Hardpoint(
                (int) Math.Round(HardpointCoordinates.X),
                (int) Math.Round(HardpointCoordinates.Y),
                ZLevel);
        }
        // Returns them in distance order
        public IList<Hardpoint> NearestNHardpoints(int n)
        {
            if (n > 9)
            {
                throw new NotImplementedException();
            }

            int startX = ((int) HardpointCoordinates.X) - 1;
            int endX = startX + 3;
            int startY = ((int) HardpointCoordinates.Y) - 1;
            int endY = startY + 3;
            var candidates = new List<Hardpoint>();
            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    candidates.Add(new Hardpoint(x, y, ZLevel));
                }
            }

            return candidates
                .OrderBy((h) => DistanceSquared(HardpointCoordinates, h.ToPointF()))
                .Take(n)
                .ToList();
        }

        public float DistanceSquared(PointF a, PointF b)
        {
            return (a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y);
        }
    }
}