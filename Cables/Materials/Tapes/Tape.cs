using System;
using System.Linq;

namespace Cables.Materials
{
    public struct Tape
    {
        /// <summary>
        /// Название ленты
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Массив с объектами типа "Слой ленты"
        /// </summary>
        private TapeLayer[] tapeLayers;
        public TapeLayer[] TapeLayers
        {
            get { return tapeLayers; }
            set
            {
                if (value.Length < 1)
                    throw new ArgumentException("Число слоёв ленты не может быть меньше 1!");
                tapeLayers = value;
            }
        }

        /// <summary>
        /// Толщина ленты, мкм
        /// </summary>
        public double Thickness
        {
            get
            {
                if (TapeLayers.Length == 1)
                    return TapeLayers[0].Thickness;
                var thickness = 0d;
                foreach (var tape in TapeLayers)
                    thickness += tape.Thickness;
                return thickness;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is Tape tape)
            {
                return Name == tape.Name &&
                       TapeLayers.SequenceEqual(tape.TapeLayers);

            }
            return false;
        }

        public override int GetHashCode()
        {
            var hash = 19;
            hash = hash * 37 + Name.GetHashCode();
            hash = hash * 37 + TapeLayers.GetHashCode();
            hash = hash * 37 + Thickness.GetHashCode();
            return hash;
        }
    }
}
