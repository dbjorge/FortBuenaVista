using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace FortBuenaVista.DesktopApp
{
    public class PillarComponent : IFortressComponent
    {
        public PillarComponent(Position p)
        {
            Debug.Assert(p.ZLevel >= 0);
            Debug.Assert(p.Hardpoints.Count == 1);

            Position = p;
            ComponentType = FoundationComponentType.Pillar;
            FillColor = Color.Aquamarine;
        }

        public static PillarComponent AtPoint(Hardpoint point, int zLevel)
        {
            return new PillarComponent(new Position(new[] { point }, zLevel));
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
            var center = p.Hardpoints.First();
            const float width = .5f;
            return new RectangleF(center.X - width/2, center.Y - width/2, width, width);
        }

        public RectangleF BoundingBox { get; private set; }

        public Color FillColor { get; private set; }
        public FoundationComponentType ComponentType { get; private set; }
    }
}