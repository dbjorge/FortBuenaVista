using System.Collections.Generic;
using System.Diagnostics;

namespace FortBuenaVista.DesktopApp
{
    public class FoundationComponent : IFortressComponent
    {
        public FoundationComponent(Position p)
        {
            Debug.Assert(p.ZLevel == 0);
            Position = p;
            ComponentType = FoundationComponentType.Floor;
        }

        public static FoundationComponent FromCenterPoint(Hardpoint centerPoint)
        {
            var hardpoints = new List<Hardpoint>();
            for (int x = centerPoint.X - 1; x <= centerPoint.X + 1; x++)
            {
                for (int y = centerPoint.Y - 1; y <= centerPoint.Y + 1; y++)
                {
                    hardpoints.Add(new Hardpoint(x, y));
                }
            }
            var position = new Position(hardpoints, 0);
            return new FoundationComponent(position);
        }

        public Position Position { get; set; }
        public FoundationComponentType ComponentType { get; private set; }
    }
}