using System.Drawing;

namespace FortBuenaVista.DesktopApp
{
    // Hardpoints essentially represent any point a pillar could be placed on.
    // So, a foundation encompasses 9 hardpoints, a wall 3, a pillar 1.
    //
    // 0  1  2  3  4
    // .__.__.__.__. 0
    // |     |     |
    // *  *  *  *  * 1
    // |__.__|__.__| 2
    // |     |     |
    // *  *  *  *  * 3
    // |__.__|__.__| 4
    //
    // Note that even though that diagram is 0-based, the actual hardpoint grid
    // extends infintely in all 4 directions
    //
    // X and Y refer to the horizontal plane. Z refers to the "floor"/height.
    //
    // Z = 0 is where all foundations live. Note that there are objects, like Ramps and Boxes, that
    // could live at Z = -1.
    public struct Hardpoint
    {
        public int X;
        public int Y;
        public int Z;

        public Hardpoint(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public PointF ToPointF()
        {
            return new PointF(X, Y);
        }

        public override string ToString()
        {
            return string.Format("H({0}, {1}, {2})", X, Y, Z);
        }
    }
}