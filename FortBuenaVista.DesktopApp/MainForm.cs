using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FortBuenaVista.DesktopApp
{
    public partial class MainForm : Form
    {
        private FortressLayout fortress;
        public MainForm()
        {
            InitializeComponent();
            fortress = CreateDummyFortress();
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
            var gfx = e.Graphics;
            gfx.DrawLine(Pens.BlueViolet,new Point(10,10),new Point(27,100) );
        }
    }
}
