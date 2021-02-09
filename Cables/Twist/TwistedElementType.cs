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
        single = 1,

        /// <summary>
        /// Скрученная пара
        /// </summary>
        [Description("Пара")]
        pair = 2,

        /// <summary>
        /// Скрученная тройка
        /// </summary>
        [Description("Тройка")]
        triple = 3,

        /// <summary>
        /// Скрученная четвёрка
        /// </summary>
        [Description("Четвёрка")]
        four = 4,

        /// <summary>
        /// Скрученный сердечник со сложным набором элементов
        /// </summary>
        [Description("Сердечник")]
        core = 100
    }
}
