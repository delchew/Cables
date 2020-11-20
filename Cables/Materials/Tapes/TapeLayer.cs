using System;
namespace Cables.Materials
{
    public struct TapeLayer
    {
        public Material TapeMaterial { get; set; }

        private double thickness;
        public double Thickness
        {
            get { return thickness; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Толщина ленты не может быть меньше или равна 0!");
                thickness = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is TapeLayer tapeLayer)
            {
                return Thickness == tapeLayer.Thickness &&
                       TapeMaterial.Equals(tapeLayer.TapeMaterial);
            }
            return false;
        }

        public override int GetHashCode()
        {
            var hash = 19;
            hash = hash * 37 + Thickness.GetHashCode();
            hash = hash * 37 + TapeMaterial.GetHashCode();
            return hash;
        }
    }
}