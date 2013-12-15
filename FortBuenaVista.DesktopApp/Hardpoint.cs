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
    public struct Hardpoint
    {
        public int X;
        public int Y;

        public Hardpoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}