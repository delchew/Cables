using Cables.Materials;

namespace Cables.CableElements
{
    public class TwistedCore : ICableElement
    {
        /// <summary>
        /// Диаметр скрученной заготовки, мм
        /// </summary>
        public double Diameter { get; set; }
        /// <summary>
        /// схема скрутки
        /// </summary>
        public TwistInfo TwistInfo { get; set; }
        /// <summary>
        /// Тип скрученного элемента
        /// </summary>
        public TwistedElementType TwistedElementType { get; set; }
        /// <summary>
        /// Тип скручиваемого элемента
        /// </summary>
        public ICableElement Preform { get; set; }
        /// <summary>
        /// Шаг скрутки, мм
        /// </summary>
        public double TwistStep { get; set; }
        /// <summary>
        /// Информация о типе ленты, если присутствует
        /// </summary>
        public Tape? Tape { get; set; }
        /// <summary>
        /// Информация о типе нити, если присутствует
        /// </summary>
        public Thread Thread { get; set; }
    }
}
