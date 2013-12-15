using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace FortBuenaVista.DesktopApp
{
    // Fortress components need to understand:
    // * Its position
    // * How to be drawn, given a position
    // * A position and legality, given:
    //    - A cursor position
    //    - Relevant nearby objects (all objects? Requested objects?)
    // * How to be serialized/deserialized
    // * What materials are required to build it
    // * How hard is it to break
    // * How long will it take to decay
    //
    // The model also needs to allow for component-specific attributes (eg, door owners)
    public interface IFortressComponent
    {
        Position Position { get; set; }
        RectangleF BoundingBox { get; }
        Color FillColor { get; }

        // These are constants per component type
        FoundationComponentType ComponentType { get; }
    }

    public interface IFortressComponentRenderer
    {
        void RenderInHardpointCoordinates(Graphics graphics, IFortressComponent component);
    }
}