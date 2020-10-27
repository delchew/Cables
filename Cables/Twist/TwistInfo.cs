namespace Cables
{
    /// <summary>
    /// Структура содержит информацию с параметрами скрутки элементов кабеля
    /// </summary>
    public struct TwistInfo
    {
        /// <summary>
        /// Количество скручиваемых элементов
        /// </summary>
        public int QuantityElements { get; set; }

        /// <summary>
        /// Коэффициент скрутки
        /// </summary>
        public double TwistCoefficient { get; set; }

        /// <summary>
        /// Массив, содержащий в себе количество элементов в каждом повиве, где число элементов массива - число повивов
        /// </summary>
        public int[] LayersElementsCount { get; set; }
    }
}
