using System.Collections.Generic;

namespace FortBuenaVista.DesktopApp
{
    public class Position
    {
        public Position(IReadOnlyCollection<Hardpoint> hardpoints, int zLevel)
        {
            Hardpoints = hardpoints;
            ZLevel = zLevel;
        }

        // This collection contains ALL of the hardpoints contained by a component or its edges, inclusive, not just
        // the corners/ends
        public IReadOnlyCollection<Hardpoint> Hardpoints { get; private set; }

        // 0 is where foundations live
        // Ramps (or anything else that can be placed on the ground next to foundations) can be at -1
        public int ZLevel { get; private set; }
    }
}