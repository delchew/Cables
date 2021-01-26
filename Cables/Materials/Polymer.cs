using System.Drawing;

namespace Cables.Materials
{
    public class Polymer : Material
    {
        /// <summary>
        /// Цвет материала 
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Группа материала
        /// </summary>
        public PolymerGroup PolymerGroup { get; set; }

        /// <summary>
        /// Диэлектрическая проницаемость
        /// </summary>
        public double DielectricConstant { get; set; }
    }
}
