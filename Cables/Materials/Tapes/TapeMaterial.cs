using System;
namespace Cables.Materials
{
    public struct TapeMaterial
    {
        public string Name { get; set; }

        private double tapeMaterialDensity;
        public double TapeMaterialDensity
        {
            get { return tapeMaterialDensity; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Плотность ленты не может быть меньше или равна 0!");
                tapeMaterialDensity = value;
            }
        }

    }
}