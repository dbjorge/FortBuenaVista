using System;
using System.Collections.Generic;

namespace FortBuenaVista.DesktopApp
{
    public enum FoundationComponentType
    {
        Floor, // In a counterintuitive twist, "Ceilings" are actually floors. :dealwithit:
        Pillar,
        Wall,
        Else
    }

    // We want to use this in a SortedList so it needs to be a total ordering, not just a partial ordering
    public class ZOrderComparer : IComparer<IFortressComponent>
    {
        public int Compare(IFortressComponent x, IFortressComponent y)
        {
            var zLevelComparison = x.Position.ZLevel.CompareTo(y.Position.ZLevel);
            if (zLevelComparison != 0) { return zLevelComparison; }

            // Tiebreak: Component type
            var componentTypeComparison = x.ComponentType.CompareTo(y.ComponentType);
            if (componentTypeComparison != 0) { return componentTypeComparison; }
            
            // After this point, we don't actually care about the order except that SortedList needs the
            // order to be total. Those first two are sufficient to get drawing to happen correctly.
            return 0;
        }
    }
}