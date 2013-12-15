using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FortBuenaVista.DesktopApp
{
    // Stores all of the IFortressComponents that make up a Fortress. This class is essentially the
    // the entry point of the Fortress data model - this is the root node for any drawing/serilization.
    public class FortressLayout
    {
        private SortedList<ZOrder, IFortressComponent> components;

        public FortressLayout()
        {
            components = new SortedList<ZOrder, IFortressComponent>();
        }
        public FortressLayout(IEnumerable<IFortressComponent> components)
        {
            this.components = new SortedList<ZOrder, IFortressComponent>(components.ToDictionary(t => t.ZOrder));
        }

        public void Add(IFortressComponent component)
        {
            components.Add(component.ZOrder, component);
        }

        public IEnumerable<IFortressComponent> Components
        {
            get { return components.Values; }
        }
    }
}
