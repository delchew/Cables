using System.Drawing;

namespace Cables.Brands.Common.ColorsBuilders
{
    public struct CountingMarkingColors
    {
        public Color[] CountingColorsSet { get; set; }
        public Color[] DirectingColorsSet { get; set; }
        public Color[] OtherColorsSet { get; set; }

        public CountingMarkingColors(Color[] countingColorSet, Color[] directingColorSet, Color[] otherColorsSet)
        {
            CountingColorsSet = countingColorSet;
            DirectingColorsSet = directingColorSet;
            OtherColorsSet = otherColorsSet;
        }

    }
}
