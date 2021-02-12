using System.Collections.Generic;
using System.Drawing;

namespace Cables.Brands.Common.ColorsBuilders
{
    public interface ICableColorsBuilder<T> where T : Cable
    {
        IList<Color[]> GetCableColorsSet(T cableOrder);
        IDictionary<Color, int> GetCableColorLengthsSet(T cableOrder);
    }
}
