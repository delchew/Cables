using Cables.Materials;

namespace Cables
{ 
    public interface IExtrudable<T> : ICableElement where T : ICableElement 
    {
        ExtrusionPolymerGroup PolymerGroup { get; set; }
        T Billet { get; set; }
        double MinThickness { get; set; }
        double? NominalThickness { get; set; }
    }
}
