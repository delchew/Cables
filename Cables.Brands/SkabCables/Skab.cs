﻿using Cables.Brands.Common;

namespace Cables.Brands.SkabCables
{
    public class Skab : Cable, IIndividualFoilShields, IShield, IWaterBlockingElements, IFilled, IBraidArmoured, IArmourTube
    {
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
