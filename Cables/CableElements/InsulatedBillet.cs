using Cables.Common;
using Cables.Materials;

namespace Cables.CableElements
{
    public class InsulatedBillet : IExtrudable<IConductor>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IConductor Billet { get; set; }

        public PolymerGroup PolymerGroup { get; set; }

        public OperatingVoltageEntity OperatingVoltage { get; set; }

        public double Diameter { get; set; }

        public double MinThickness { get; set; }

        public double? NominalThickness { get; set; }
    }
}
