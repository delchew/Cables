using Cables.Brands.Common;

namespace Cables.Brands.Skab
{
    public class Skab : Cable, IIndividualFoilShields, IShield, IWaterBlockingElements, IFilled, IBraidArmoured, IArmourTube
    {
        public SkabVoltageType VoltageType { get; set; }

        public bool HasIndividualFoilShields { get; set; }

        public bool HasFoilShield { get; set; }

        public bool HasBraidShield { get; set; }

        public bool HasFilling { get; set; }

        public bool HasBraidArmour{ get; set; }

        public bool HasArmourTube { get; set; }

        public bool HasWaterBlockingElements { get; set; }

        public bool SparkSafety { get; set; }
    }
}
