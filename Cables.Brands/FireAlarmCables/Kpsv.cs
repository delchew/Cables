using Cables.Brands.Common;

namespace Cables.Brands.FireAlarmCables
{
    public class Kpsv : Cable, ISingleConstruction, IFoilShield, IBraidArmoured, IArmourTube
    {
        public bool HasFoilShield { get; set; }

        public bool HasBraidArmour { get; set; }

        public bool HasArmourTube { get; set; }
    }
}
