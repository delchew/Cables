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
        /// Тип материала: пластик или резина
        /// </summary>
        public PolymerType PolymerType { get; set; }

        /// <summary>
        /// Назначение материала: изоляция, заполнение или оболочка
        /// </summary>
        public PolymerUsingType UsingType { get; set; }
    }
}
