using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FortBuenaVista.DesktopApp
{
    // Stores all of the IFortressComponents that make up a Fortress. This class is essentially the
    // the entry point of the Fortress data model - this is the root node for any drawing/serilization.
    public class FortressLayout
    {
        private struct ComponentKey
        {
            private static int componentCounter = 0;
            public IFortressComponent Component;
            public int TiebreakId;

            public ComponentKey(IFortressComponent component)
            {
                Component = component;
                TiebreakId = Interlocked.Increment(ref componentCounter);
            }
        }

        // We can't use ZOrderComparer on its own because SortedList needs a total ordering
        private class ZOrderWithTiebreakComparer : IComparer<ComponentKey>
        {
            private ZOrderComparer baseComparer = new ZOrderComparer();
            public int Compare(ComponentKey x, ComponentKey y)
            {
                var baseCompare = baseComparer.Compare(x.Component, y.Component);
                return baseCompare != 0 ? baseCompare : (x.TiebreakId.CompareTo(y.TiebreakId));
            }
        }

        int Id { get; set; }

        private SortedList<ComponentKey, IFortressComponent> componentsByZOrder
            = new SortedList<ComponentKey, IFortressComponent>(new ZOrderWithTiebreakComparer());
        private IDictionary<Hardpoint, ICollection<IFortressComponent>> componentsByHardpoint
            = new Dictionary<Hardpoint, ICollection<IFortressComponent>>();

        public FortressLayout() { }

        public FortressLayout(IEnumerable<IFortressComponent> components)
        {
            foreach (var c in components)
            {
                Add(c);
            }
        }

        public void Add(IFortressComponent component)
        {
            componentsByZOrder.Add(new ComponentKey(component), component);
            foreach (var h in component.Position.Hardpoints)
            {
                if (!componentsByHardpoint.ContainsKey(h))
                {
                    componentsByHardpoint[h] = new List<IFortressComponent>(); 
                }
                componentsByHardpoint[h].Add(component);
            }
        }

        public IEnumerable<IFortressComponent> ComponentsByZOrder
        {
            get { return componentsByZOrder.Values; }
        }

        public IEnumerable<IFortressComponent> ComponentsByHardpoint(Hardpoint h)
        {
            return componentsByHardpoint.ContainsKey(h) ? componentsByHardpoint[h] : Enumerable.Empty<IFortressComponent>();
        }
    }
}
