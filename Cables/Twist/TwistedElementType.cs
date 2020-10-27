using System.ComponentModel;

namespace Cables
{
    /// <summary>
    /// Представляет тип скрученного элемента
    /// </summary>
    public enum TwistedElementType
    {
        /// <summary>
        /// Одиночный элемент
        /// </summary>
        [Description("Одиночный")]
        single,

        /// <summary>
        /// Скрученная пара
        /// </summary>
        [Description("Пара")]
        pair,

        /// <summary>
        /// Скрученная тройка
        /// </summary>
        [Description("Тройка")]
        triple,

        /// <summary>
        /// Скрученная четвёрка
        /// </summary>
        [Description("Четвёрка")]
        four,

        /// <summary>
        /// Скрученный сердечник со сложным набором элементов
        /// </summary>
        [Description("Сердечник")]
        core
    }
}
