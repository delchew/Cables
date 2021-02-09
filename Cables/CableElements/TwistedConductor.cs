using Cables.Materials;

namespace Cables.CableElements
{
    /// <summary>
    /// Класс описывает конструкцию скрученной токопроводящей жилы
    /// </summary>
    public class TwistedConductor : IConductor
    {
        public int Id { get; set; }

        /// <summary>
        /// Название скрученной токопроводящей жилы
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Число проволок для скрученной жилы, 
        /// </summary>
        public int ElementsCount { get; set; }

        /// <summary>
        /// Одиночный элемент скрученной токопроводящей жилы
        /// </summary>
        public IConductor SingleElement { get; set; }

        /// <summary>
        /// Диаметр токопроводящей жилы, мм
        /// </summary>
        public double Diameter { get; set; }

        /// <summary>
        /// Заявленная площадь поперечного сечения токопроводящей жилы в мм²
        /// </summary>
        public double? DeclaredAreaInSqrMm { get; set; }

        /// <summary>
        /// Материал токопроводящей жилы
        /// </summary>
        public Metal Material 
        {
            get => SingleElement.Material;
            set => SingleElement.Material = value;
        }

        /// <summary>
        /// Класс токопродящей жилы
        /// </summary>
        public int ConductorClass { get; set; }
    }
}
