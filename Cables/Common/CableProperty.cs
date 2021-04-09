using System;

namespace Cables.Common
{
    [Flags]
    public enum CablePropertySet
    {
        HasFoilShield = 1,

        HasBraidShield = 2,

        HasArmourBraid = 4,

        HasArmourTape = 8,

        HasArmourTube = 16,

        HasFilling = 32,

        HasIndividualFoilShields = 64,

        HasIndividualBraidShield = 128,

        HasWaterBlockStripe = 256,

        SparkSafety = 512
    }
}
