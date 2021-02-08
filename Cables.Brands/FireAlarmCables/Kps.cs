using Cables.Brands.Common;

namespace Cables.Brands.FireAlarmCables
{
    public class Kps : Cable, ISingleConstruction, IMicable, IFoilShield
    {
        public bool HasMica { get; set; }

        public bool HasFoilShield { get; set; }
    }
}
