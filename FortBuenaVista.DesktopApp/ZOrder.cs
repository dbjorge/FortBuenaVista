using System;

namespace FortBuenaVista.DesktopApp
{
    public class ZOrder : IComparable<ZOrder>
    {
        public ZOrder(int order)
        {
            Order = order;
        }

        public int Order { get; private set; }


        public int CompareTo(ZOrder other)
        {
            return this.Order.CompareTo(other.Order);
        }
    }
}