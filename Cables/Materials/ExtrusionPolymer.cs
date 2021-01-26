using System.Drawing;
namespace Cables.Materials
{
    public class ExtrusionPolymer : Polymer
    {
        /// <summary>
        /// Цвет материала 
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Тип материала
        /// </summary>
        public ExtrusionPolymerGroup PolymerType { get; set; }

        /// <summary>
        /// Назначение материала: изоляция, заполнение или оболочка
        /// </summary>
        public ExtrusionPolymerUsingType UsingType { get; set; }
    }
}
