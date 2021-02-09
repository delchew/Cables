using Cables.Brands.Common;
using Cables.Common;

namespace Cables.Brands.KunrsCables
{
    public class Kunrs : Cable, IFoilShield, IFilled, IBraidArmoured, IArmourTube
    {
        public bool HasFoilShield { get; set; }

        public bool HasFilling { get; set; }

        public bool HasBraidArmour { get; set; }

        public bool HasArmourTube { get; set; }

        public PowerWiresColorScheme PowerColorScheme { get; set; }
    }
}
