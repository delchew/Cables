using Cables.Materials;

namespace Cables.CableElements
{
    /// <summary>
    /// Класс, описывающий сплошную токопроводящую жилу
    /// </summary>
    public class SolidConductor : IConductor
    {
        public int Id { get; set; }

        /// <summary>
        /// Название токопроводящей жилы
        /// </summary>
        public string Title { get; set; }

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
