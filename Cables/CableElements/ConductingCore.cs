using Cables.Materials;

namespace Cables
{
    /// <summary>
    /// Класс описывает конструкцию токопроводящей жилы
    /// </summary>
    public struct ConductingCore : ICableElement
    {
        /// <summary>
        /// Материал проводника
        /// </summary>
        public Metal WireMaterial { get; set; }

        /// <summary>
        /// Диаметр токопроводящей жилы, мм
        /// </summary>
        public double Diameter { get; set; }

        /// <summary>
        /// Число проволок для скрученной жилы, 1 - если жила сплошная
        /// </summary>
        public int WiresCount { get; set; }

        /// <summary>
        /// Площадь поперечного сечения жилы, мм²
        /// </summary>
        public double AreaInSquareMillimetres { get; set; }
    }
}
