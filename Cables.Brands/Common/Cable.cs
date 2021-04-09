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

        public TechnicalConditionsEntity TechConditions { get; set; }

        public FireProtectionClassEntity FireProtectionClass { get; set; }

        public PolymerGroup CoverPolymerGroup { get; set; }

        public CableColor CoverColor { get; set; }

        public double? MaxCableDiameter { get; set; }

        public ClimaticModification ClimaticModification { get; set; }

        public OperatingVoltageEntity OperatingVoltage { get; set; }

        public CablePropertySet CablePropertySet { get; set; }
    }
}
