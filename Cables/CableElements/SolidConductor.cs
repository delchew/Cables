using Cables.Materials;

namespace Cables
{
    /// <summary>
    /// Класс, описывающий сплошную токопроводящую жилу
    /// </summary>
    public class SolidConductor : IConductor
    {
        /// <summary>
        /// Диаметр токопроводящей жилы в мм
        /// </summary>
        public double Diameter { get; set; }

        /// <summary>
        /// Заявленная площадь поперечного сечения токопроводящей жилы в мм²
        /// </summary>
        public double? DeclaredAreaInSqrMm { get; set; }

        /// <summary>
        /// Материал токопроводящей жилы
        /// </summary>
        public Metal Material { get; set; }

        /// <summary>
        /// Класс токопродящей жилы
        /// </summary>
        public int ConductorClass { get; set; }
    }
}
