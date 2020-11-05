using Cables.Materials;
using System;

namespace Cables
{
    public class WindingBuider
    {
        /// <summary>
        /// Рассчитывает угол обмотки ленты в градусах °
        /// </summary>
        /// <param name="windingStep">Шаг обмотки леты, мм</param>
        /// <param name="windingCoreDiameter">Диаметр обматываемой заготовки, мм</param>
        /// <param name="tapeThickness">Толщина ленты, мкм</param>
        /// <returns>Угол обмотки ленты в градусах °</returns>
        public static double CalculateWindingAngle(double windingStep, double windingCoreDiameter, double tapeThickness)
        {
            return Math.Acos(1 / (Math.Sqrt(1 + (Math.Pow((windingStep / (Math.PI * (windingCoreDiameter + tapeThickness * 0.001))), 2))))) * 180 / Math.PI;
        }

        /// <summary>
        /// Рассчитывает перекрытие ленты при обмотке, %
        /// </summary>
        /// <param name="windingStep">Шаг обмотки леты, мм</param>
        /// <param name="tapeWidth">Ширина ленты, мм</param>
        /// <param name="windingCoreDiameter">Диаметр обматываемой заготовки, мм</param>
        /// <param name="tapeThickness">Толщина ленты, мкм</param>
        /// <returns>Перекрытие ленты при обмотке, %</returns>
        public static double CalculateWindingOverlap(double windingStep, double tapeWidth, double windingCoreDiameter, double tapeThickness)
        {
            var cos = 1 / (Math.Sqrt(1 + (Math.Pow((windingStep / (Math.PI * (windingCoreDiameter + tapeThickness * 0.001))), 2))));
            return -100 * (((windingStep * cos) / tapeWidth) - 1);
        }

        /// <summary>
        /// Рассчитывает расход ленты на 1км заготовки, км
        /// </summary>
        /// <param name="windingStep">Шаг обмотки леты, мм</param>
        /// <param name="windingCoreDiameter">Диаметр обматываемой заготовки, мм</param>
        /// <param name="tapeThickness">Толщина ленты, мкм</param>
        /// <returns>Расход ленты на 1км заготовки, км</returns>
        public static double CalculateTapeLength(double windingStep, double windingCoreDiameter, double tapeThickness)
        {
            return Math.Sqrt(Math.Pow(windingStep, 2) + Math.Pow(Math.PI * (windingCoreDiameter + tapeThickness * 0.001), 2)) / windingStep;
        }

        /// <summary>
        /// Рассчитывает расход ленты на 1км заготовки, кг
        /// </summary>
        /// <param name="tape">Объект, содержащий информацию о ленте</param>
        /// <param name="windingStep">Шаг обмотки леты, мм</param>
        /// <param name="windingCoreDiameter">Диаметр обматываемой заготовки, мм</param>
        /// <param name="tapeWidth">Ширина ленты, мм</param>
        /// <returns>Расход ленты на 1км заготовки, кг</returns>
        public static double CalculateTapeWeight(Tape tape, double windingStep, double windingCoreDiameter, double tapeWidth)
        {
            double oneMeterTapeWeight = 0;
            for (int i = 0; i < tape.TapeLayers.Length; i++)
            {
                oneMeterTapeWeight += tape.TapeLayers[i].TapeMaterial.Density20 * tape.TapeLayers[i].Thickness * tapeWidth;
            }
            return oneMeterTapeWeight * CalculateTapeLength(windingStep, windingCoreDiameter, tape.Thickness) / 1000000;
        }
    }
}
