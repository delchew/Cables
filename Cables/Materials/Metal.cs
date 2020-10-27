using System;

namespace Cables.Materials
{
    public struct Metal
    {
        /// <summary>
        /// Название материала 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Электрическое сопротивление в Ом/км, при 20°С
        /// </summary>
        public double ElectricalResistance20 { get; set; }

        /// <summary>
        /// Плотность в кг/м³, при 20°С
        /// </summary>
        public int Density20 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Metal metal)
            {
                return Name == metal.Name &&
                       ElectricalResistance20 == metal.ElectricalResistance20 &&
                       Density20 == metal.Density20;
            }
            throw new InvalidCastException($"Объект не является типом {GetType()}");
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
