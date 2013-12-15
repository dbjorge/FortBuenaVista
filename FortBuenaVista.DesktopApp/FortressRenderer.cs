using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FortBuenaVista.DesktopApp
{
    public class FortressRenderer
    {
        public FortressRenderer()
        {
            HardpointViewingWindow = new RectangleF(-10, -10, 20, 20);
        }
        public RectangleF HardpointViewingWindow { get; set; }
        public void RenderInUiCoordinates(Graphics graphics, FortressLayout fortress)
        {
            var originalState = graphics.Save();
            graphics.TranslateTransform(-HardpointViewingWindow.X, -HardpointViewingWindow.Y);
            graphics.ScaleTransform(50, 50);
            RenderInHardpointCoordinates(graphics, fortress);
            graphics.Restore(originalState);
        }

        public void RenderInHardpointCoordinates(Graphics graphics, FortressLayout fortress)
        {
            var brush = new SolidBrush(Color.Black);
            var pen = Pens.Black;
            pen.ScaleTransform((float) (1.0 / 25.0), (float) (1.0 / 25.0), MatrixOrder.Append);

            // Perf optimization for later: don't render components outside the viewing window
            foreach (var component in fortress.ComponentsByZOrder)
            {
                brush.Color = component.FillColor;
                var bbox = component.BoundingBox;
                graphics.FillRectangle(brush, bbox);
                
                graphics.DrawRectangle(pen, bbox.X, bbox.Y, bbox.Width, bbox.Height);
            }
            pen.ResetTransform();
        }
    }
}