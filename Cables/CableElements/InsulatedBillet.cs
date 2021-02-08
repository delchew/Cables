using Cables.Materials;

namespace Cables.CableElements
{
    public class InsulatedBillet : IExtrudable<IConductor>
    {
        public IConductor Billet { get; set; } //public long ConductorId { get; set; }

        public PolymerGroup PolymerGroup { get; set; } //public long PolymerGroupId { get; set; }

        public string ShortName { get; set; } //public long CableShortNameId { get; set; }

        public double Diameter { get; set; } //public decimal Diameter { get; set; }

        public double MinThickness { get; set; } //public decimal MinThickness { get; set; }

        public double? NominalThickness { get; set; } //public decimal? NominalThickness { get; set; }

    }
}
