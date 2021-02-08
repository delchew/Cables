using Cables.Materials;

namespace Cables.CableElements
{ 
    public interface IExtrudable<T> : ICableElement where T : ICableElement 
    {
        PolymerGroup PolymerGroup { get; set; }

        T Billet { get; set; }

        double MinThickness { get; set; }

        double? NominalThickness { get; set; }
    }
}
