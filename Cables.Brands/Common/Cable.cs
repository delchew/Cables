using Cables.CableElements;
using Cables.Common;
using Cables.Materials;

namespace Cables.Brands.Common
{
    public class Cable : ISingleConstruction
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public InsulatedBillet InsulatedBillet { get; set; }

        public int ElementsCount { get; set; }

        public TwistedElementType TwistedElementType { get; set; }

        public TechnicalConditions TechConditions { get; set; }

        public FireProtectionClass FireProtectionClass { get; set; }

        public PolymerGroup CoverPolymerGroup { get; set; }

        public CableColor CoverColor { get; set; }

        public double? MaxCableDiameter { get; set; }

        public ClimaticModification ClimaticModification { get; set; }

        public OperatingVoltage OperatingVoltage { get; set; }

        public CableProperty CableProperties { get; set; }
    }
}
