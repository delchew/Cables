using System;

namespace Cables.Materials
{
    public struct Tape
    {
        public string Name { get; set; }

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

        //private double width;
        //public double Width
        //{
        //    get { return width; }
        //    set
        //    {
        //        if (value <= 0)
        //            throw new ArgumentException("Ширина ленты не может быть меньше или равна 0!");
        //        width = value;
        //    }
        //}

        public double Thickness
        {
            get
            {
                if (TapeLayers.Length == 1)
                    return TapeLayers[0].Thickness;
                var thickness = 0d;
                foreach (var tape in TapeLayers)
                {
                    thickness += tape.Thickness;
                }
                return thickness;
            }
        }
    }
}
