using System.Linq;

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

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if(obj is TwistInfo twistInfo)
            {
                return QuantityElements == twistInfo.QuantityElements &&
                       TwistCoefficient == twistInfo.TwistCoefficient &&
                       LayersElementsCount.SequenceEqual(twistInfo.LayersElementsCount);
            }
            return false;
        }

        public override int GetHashCode()
        {
            var hash = 19;
            hash = hash * 37 + QuantityElements.GetHashCode();
            hash = hash * 37 + TwistCoefficient.GetHashCode();
            hash = hash * 37 + LayersElementsCount.GetHashCode();
            return hash;
        }
    }
}
