using System;

namespace Cables.Materials
{
    public abstract class Material
    {
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
                    throw new ArgumentException("Должно быть задано конкретное название для материала!");
                name = value;
            }
        }

        private int density20;

        /// <summary>
        /// Плотность в кг/м³, при 20°С
        /// </summary>
        public int Density20
        {
            get { return density20; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Плотность материала не может быть меньше или равна 0!");
                density20 = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is Material material)
            {
                return Name == material.Name &&
                       Density20 == material.Density20;
            }
            return false;
        }

        public override int GetHashCode()
        {
            var hash = 19;
            hash = hash * 37 + Name.GetHashCode();
            hash = hash * 37 + Density20.GetHashCode();
            return hash;
        }
    }
}
