using System;

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
            if (obj is TwistInfo twistInfo)
            {
                return QuantityElements == twistInfo.QuantityElements &&
                       TwistCoefficient == twistInfo.TwistCoefficient &&
                       CompareArrays(LayersElementsCount, twistInfo.LayersElementsCount);
            }
            throw new InvalidCastException($"Объект не является типом {GetType()}");
        }

        private bool CompareArrays(int[] arr1, int[] arr2)
        {
            if (arr1.Length != arr2.Length)
                return false;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
