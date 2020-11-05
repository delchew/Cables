using System;
namespace Cables.Materials
{
    public struct TapeLayer
    {
        public IMaterial TapeMaterial { get; set; }

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
    }
}