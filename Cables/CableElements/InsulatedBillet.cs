using Cables.Materials;

namespace Cables
{
    public class InsulatedBillet : IExtrudable<IConductor>
    {
        public ExtrusionPolymerGroup PolymerGroup { get; set; }
        public IConductor Billet { get; set; } 
        public double MinThickness { get; set; }
        public double? NominalThickness { get; set; }

        public double Diameter { get; set; }
    }
}
