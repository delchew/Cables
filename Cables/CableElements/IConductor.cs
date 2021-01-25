using Cables.Materials;

namespace Cables
{
    public interface IConductor : ICableElement
    {
        double? DeclaredAreaInSqrMm { get; set; }

        Metal Material { get; set; }

        int ConductorClass { get; set; }
    }
}
