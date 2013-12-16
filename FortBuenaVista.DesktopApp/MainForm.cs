using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
                FoundationComponent.AtCenterPoint(new Hardpoint(1, 1, 0)),
                FoundationComponent.AtCenterPoint(new Hardpoint(3, 1, 0)),
                FoundationComponent.AtCenterPoint(new Hardpoint(1, 3, 0)),
                FoundationComponent.AtCenterPoint(new Hardpoint(3, 3, 0)),
                PillarComponent.AtPoint(new Hardpoint(2, 2, 0))
            };
            return new FortressLayout(dummyComponents);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void ComponentButton_CheckedChanged(object sender, System.EventArgs e)
        {
            var buttonPlacerMapping = new Dictionary<object, IPlacer>();
            buttonPlacerMapping[FoundationButton] = new FoundationPlacer();
            buttonPlacerMapping[PillarButton] = new PillarPlacer();

            ActivePlacer = buttonPlacerMapping[sender];
        }

        public IPlacer ActivePlacer { get; private set; }

        private void CanvasPanel_Paint(object sender, PaintEventArgs e)
        {
            renderer.RenderInUiCoordinates(e.Graphics, fortress);
        }
    }

    public class PillarPlacer : IPlacer
    {
        public SnapCandidate Snap(UserCoordinates userCoordinates, FortressLayout layout)
        {
            var hardpoint = userCoordinates.NearestHardpoint();
            var overlaps = layout.ComponentsByHardpoint(hardpoint).ToList();

            var isLegal =
                overlaps.Any(c => c.ComponentType == FoundationComponentType.Floor) &&
                overlaps.All(c => c.ComponentType != FoundationComponentType.Pillar);

            var candidate = new SnapCandidate()
            {
                Position = Position.OneByOneAt(hardpoint),
                BoundingBox = new RectangleF(hardpoint.X - .1f, hardpoint.Y - .1f, .2f, .2f),
                IsLegal = isLegal
            };

            return candidate;
        }
    }

    public class FoundationPlacer : IPlacer
    {
        public IEnumerable<IFortressComponent> GetNeighboringFoundations(Position p, FortressLayout layout)
        {
            // There's no need to check the sides or center - foundations are 2x2, so any foundation
            // touching a non-corner hardpoint must also touch a corner hardpoint.
            return p.GetCorners()
                .SelectMany(layout.ComponentsByHardpoint)
                .Where(c => c.ComponentType == FoundationComponentType.Floor)
                .Distinct();
        }

        public SnapCandidate Snap(UserCoordinates userCoordinates, FortressLayout layout)
        {
            var centerPoint = userCoordinates.NearestHardpoint();
            var candidatePosition = Position.ThreeByThreeCenteredAt(centerPoint);

            bool isLegal = false;
            var isBlocked = layout.ComponentsByHardpoint(centerPoint)
                .Any(c => c.ComponentType == FoundationComponentType.Floor);
            if (!isBlocked)
            {
                var neighbors = GetNeighboringFoundations(candidatePosition, layout);
                var hasMisalignedNeighbor = neighbors.Any(
                    n => n.Position.OverlapWith(candidatePosition).Hardpoints.Count == 2);
                isLegal = !hasMisalignedNeighbor;
            }

            var candidate = new SnapCandidate()
            {
                Position = candidatePosition,
                BoundingBox = new RectangleF(centerPoint.X - .1f, centerPoint.Y - .1f, .2f, .2f),
                IsLegal = isLegal
            };

            return candidate;
        }
    }

    public struct SnapCandidate
    {
        public Position Position;
        public RectangleF BoundingBox;
        public bool IsLegal;
    }

    public interface IPlacer
    {
        SnapCandidate Snap(UserCoordinates userCoordinates, FortressLayout layout);
    }

    // Represents a user's mouse/touch position in Hardpoint coordinates
}
