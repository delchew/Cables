using System.Drawing;
namespace Cables.Materials
{
    public struct Polymer
    {
        /// <summary>
        /// Название материала 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Плотность в кг/м³, при 20°С
        /// </summary>
        public int Density20 { get; set; }

        /// <summary>
        /// Диэлектрическая проницаемость
        /// </summary>
        public double DielectricConstant { get; set; }

        /// <summary>
        /// Цвет материала 
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Тип материала: пластик или резина
        /// </summary>
        public PolymerType PolymerType { get; set; }

        /// <summary>
        /// Назначение материала: изоляция, заполнение или оболочка
        /// </summary>
        public PolymerUsingType UsingType { get; set; }
    }
}
