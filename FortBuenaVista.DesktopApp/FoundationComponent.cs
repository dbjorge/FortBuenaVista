using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace FortBuenaVista.DesktopApp
{
    public class FoundationComponent : IFortressComponent
    {
        public FoundationComponent(Position p)
        {
            Position = p;
            ComponentType = FoundationComponentType.Floor;
            FillColor = Color.LightGreen;
        }

        public static FoundationComponent AtCenterPoint(Hardpoint centerPoint)
        {
            return new FoundationComponent(Position.ThreeByThreeCenteredAt(centerPoint));
        }

        private Position _position;
        public Position Position
        {
            get { return _position; }
            set
            {
                BoundingBox = CalculateBoundingBox(value);
                _position = value;
            }
        }

        public RectangleF CalculateBoundingBox(Position p)
        {
            var hardpoints = p.Hardpoints.ToList();
            // This could be more efficient, but I don't care since it isn't calculated often
            hardpoints.Sort((a, b) => (a.X - b.X)*10 + (a.Y-b.Y));
            return new RectangleF(hardpoints[0].X, hardpoints[0].Y, 2, 2);
        }

        public RectangleF BoundingBox { get; private set; }

        public Color FillColor { get; private set; }
        public FoundationComponentType ComponentType { get; private set; }
    }
}