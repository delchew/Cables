using Cables.Brands.Common;

namespace Cables.Brands.Kip
{
    public class Kip : Cable, IShield, IBraidArmoured, IArmourTube
    {
        public bool HasFoilShield { get; set; }

        public bool HasBraidShield { get; set; }

        public bool HasBraidArmour { get; set; }

        public bool HasArmourTube { get; set; }
    }
}
