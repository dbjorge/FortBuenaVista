using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FortBuenaVista.DesktopApp
{
    public class FortressRenderer
    {
        public FortressRenderer()
        {
            HardpointViewingWindow = new RectangleF(-10f, -10f, 20f, 20f);
            ScaleFactor = 40f;
        }
        public RectangleF HardpointViewingWindow { get; set; }
        public float ScaleFactor { get; set; }

        public void RenderInUiCoordinates(Graphics graphics, FortressLayout fortress)
        {
            var originalState = graphics.Save();
            graphics.TranslateTransform(-HardpointViewingWindow.X, -HardpointViewingWindow.Y);
            graphics.ScaleTransform(ScaleFactor, ScaleFactor);
            RenderInHardpointCoordinates(graphics, fortress);
            graphics.Restore(originalState);
        }

        public void RenderInHardpointCoordinates(Graphics graphics, FortressLayout fortress)
        {
            var brush = new SolidBrush(Color.Black);
            var pen = Pens.Black;
            var penScaleFactor = 1f / (ScaleFactor / 2f);
            pen.ScaleTransform(penScaleFactor, penScaleFactor, MatrixOrder.Append);

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