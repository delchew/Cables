using System;
namespace Cables.Materials
{
    public struct TapeMaterial : IMaterial
    {
        public string Name { get; set; }

        private int tapeMaterialDensity;
        public int Density20
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