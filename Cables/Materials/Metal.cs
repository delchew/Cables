using System;

namespace Cables.Materials
{
    public struct Metal : IMaterial
    {
        private int density20;
        private double electricalResistance20;
        private string name;

        /// <summary>
        /// Название материала 
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Должно быть задано конкретное название для металла!");
                name = value;
            }
        }

        /// <summary>
        /// Электрическое сопротивление в Ом/км, при 20°С
        /// </summary>
        public double ElectricalResistance20
        {
            get { return electricalResistance20; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Электрическое сопротивление металла не может быть меньше или равно 0!");
                electricalResistance20 = value;
            }
        }

        /// <summary>
        /// Плотность в кг/м³, при 20°С
        /// </summary>
        public int Density20
        {
            get { return density20; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Плотность ленты не может быть меньше или равна 0!");
                density20 = value;
            }
        }

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
