﻿using Cables.Materials;

namespace Cables.CableElements
{
    public class ExtrusionElement : ICableElement
    {
        public double Diameter => Preform.Diameter + 2 * Thickness;
        public ICableElement Preform { get; set; }
        public Polymer ExtrusionMaterial { get; set; }
        public double Thickness { get; set; }
        public ExtrusionOverlayType OverlayType { get; set; }
    }
}
