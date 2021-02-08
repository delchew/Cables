using Cables.CableElements;

namespace Cables.Brands.Common
{
    public interface ISingleConstruction
    {
        InsulatedBillet InsulatedBillet { get; set; }

        int ElementsCount { get; set; }

        TwistedElementType TwistedElementType { get; set; }
    }
}
