using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FortBuenaVista.DesktopApp
{
    public class Position
    {
        public Position(IEnumerable<Hardpoint> hardpoints)
            : this(hardpoints.ToList())
        { }

        public Position(IReadOnlyCollection<Hardpoint> hardpoints)
        {
            Debug.Assert(hardpoints.Any());
            Debug.Assert(hardpoints.All(h => h.Z == hardpoints.First().Z));
            Hardpoints = hardpoints;
        }

        // This collection contains ALL of the hardpoints contained by a component or its edges, inclusive, not just
        // the corners/ends
        public IReadOnlyCollection<Hardpoint> Hardpoints { get; private set; }

        public int ZLevel { get { return Hardpoints.First().Z; } }
        public static Position ThreeByThreeCenteredAt(Hardpoint center)
        {
            var hardpoints = new List<Hardpoint>();
            for (int x = center.X - 1; x <= center.X + 1; x++)
            {
                for (int y = center.Y - 1; y <= center.Y + 1; y++)
                {
                    hardpoints.Add(new Hardpoint(x, y, center.Z));
                }
            }
            return new Position(hardpoints);
        }

        public static Position OneByOneAt(Hardpoint point)
        {
            return new Position(new[] { point });
        }

        public IEnumerable<Hardpoint> GetCorners()
        {
            throw new System.NotImplementedException();
        }

        public Position OverlapWith(Position other)
        {
            return new Position(Hardpoints.Intersect(other.Hardpoints));
        }
    }
}