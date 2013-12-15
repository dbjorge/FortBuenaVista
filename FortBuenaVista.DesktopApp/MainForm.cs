using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FortBuenaVista.DesktopApp
{
    public partial class MainForm : Form
    {
        private FortressLayout fortress;
        private FortressRenderer renderer;
        public MainForm()
        {
            InitializeComponent();
            fortress = CreateDummyFortress();
            renderer = new FortressRenderer();
        }

        private FortressLayout CreateDummyFortress()
        {
            var dummyComponents = new IFortressComponent[]
            {
                FoundationComponent.FromCenterPoint(new Hardpoint(1, 1)),
                FoundationComponent.FromCenterPoint(new Hardpoint(3, 1)),
                FoundationComponent.FromCenterPoint(new Hardpoint(1, 3)),
                FoundationComponent.FromCenterPoint(new Hardpoint(3, 3))
            };
            return new FortressLayout(dummyComponents);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            renderer.RenderInUiCoordinates(e.Graphics, fortress);
        }
    }
}
