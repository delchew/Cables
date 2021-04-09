using System;

namespace Cables.Common
{
    public static class CableCalculations
    {
        /// <summary>
        /// Рассчитывает максимальную длину кабеля заданного диаметра, которая влезет на барабан с заданными параметрами, м (округлённое до ближайшего целого)
        /// </summary>
        /// <param name="reelDiameter">Диаметр барабана, мм</param>
        /// <param name="barrelDiameter">Диаметр живота барабана, мм</param>
        /// <param name="lengthBetweenFlanges">Расстояние между щёками барабана, мм</param>
        /// <param name="deltaToEdge">Расстояние от края намотки до края барабана, мм</param>
        /// <param name="cableDiameter">Диаметр наматываемой заготовки, мм</param>
        /// <returns>Максимальная длина кабеля заданного диаметра, которая влезет на барабан с заданными параметрами, м</returns>
        public static double CalculateMaxCableLengthOnReel(double reelDiameter, double barrelDiameter, double lengthBetweenFlanges, double deltaToEdge, double cableDiameter)
        {
            return Math.Round(Math.PI * lengthBetweenFlanges * (Math.Pow(reelDiameter - 2 * deltaToEdge, 2) - barrelDiameter * barrelDiameter) / (4000 * cableDiameter * cableDiameter));
        }

        /// <summary>
        /// Форматирует число с плавающей точкой, определяющее площадь кабельного проводника в правильный формат кабельной маркировки
        /// </summary>
        /// <param name="areaInSqrMm">Площадь сечения проводника</param>
        /// <returns>Строковое представление сечения кабельного проводника с нужным количеством нулей</returns>
        public static string FormatConductorArea(double areaInSqrMm)
        {
            if (areaInSqrMm < 4 && areaInSqrMm * 100 % 10 == 0)
                return string.Format("{0:f1}", areaInSqrMm);
            return areaInSqrMm.ToString();
        }

        public static string FormatConductorArea(decimal areaInSqrMm)
        {
            if (areaInSqrMm < 4 && areaInSqrMm * 100 % 10 == 0)
                return string.Format("{0:f1}", areaInSqrMm);
            return areaInSqrMm.ToString();
        }

    }
}