using System.ComponentModel;

namespace Cables.Materials
{
    public enum PolymerGroup
    {
        [Description("ПВХ пластикат")]
        PVC = 1,

        [Description("Полиэтилен")]
        PE = 2,

        [Description("Резина")]
        Rubber = 3,

        [Description("Безгалогенный компаунд")]
        HFCompound = 4,

        [Description("Полиуретан")]
        PUR = 5,

        [Description("ПВХ пластикат LS")]
        PVC_LS = 6,

        [Description("ПВХ пластикат LSLTx")]
        PVC_LSLTx = 7,

        [Description("Резина LTx")]
        RubberLTx = 8
    }
}
