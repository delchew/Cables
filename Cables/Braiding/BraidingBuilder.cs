using Cables.Materials;
using System;

namespace Cables.Braiding
{
    public class BraidingBuilder
    {
        /// <summary>
        /// Рассчитывает плотность оплётки сердечника в %
        /// </summary>
        /// <param name="spoolCounts">Число катушек</param>
        /// <param name="wireCounts">Число проволок в пасьме</param>
        /// <param name="braidingStep">Шаг оплётки, мм</param>
        /// <param name="braidingCoreDiameter">Диаметр оплетаемой заготовки, мм</param>
        /// <param name="wireDiameter">Диаметр проволок пасьмы, мм</param>
        /// <returns>Плотность оплётки, %</returns>
        public static double CalculateBraidingDensity(int spoolCounts, int wireCounts, double braidingStep, double braidingCoreDiameter, double wireDiameter)
        {
            var angle = CalculateBraidingAngle(braidingStep, braidingCoreDiameter, wireDiameter) * Math.PI / 180; // угол оплётки в радианах
            var P = (spoolCounts / 2) * wireCounts * wireDiameter * 0.001 / (braidingStep * 0.001 * Math.Cos(angle));
            return 100 * (2 * P - P * P);
        }

        /// <summary>
        /// Рассчитывает угол оплётки в градусах °
        /// </summary>
        /// <param name="braidingStep">Шаг оплётки, мм</param>
        /// <param name="braidingCoreDiameter">Диаметр оплетаемой заготовки, мм</param>
        /// <param name="wireDiameter">Диаметр проволок пасьмы, мм</param>
        /// <returns>Угол оплётки, °</returns>
        public static double CalculateBraidingAngle(double braidingStep, double braidingCoreDiameter, double wireDiameter)
        {
            return Math.Atan(braidingStep * 0.001 / (Math.PI * (braidingCoreDiameter * 0.001 + 2 * wireDiameter * 0.001))) * 180 / Math.PI;
        }

        /// <summary>
        /// Рассчитывает массу оплётки, кг/км
        /// </summary>
        /// <param name="spoolCounts">Число катушек</param>
        /// <param name="wireCounts">Число проволок в пасьме</param>
        /// <param name="wireDiameter">Диаметр проволок пасьмы, мм</param>
        /// <param name="braidingAngle">Угол оплётки в градусах °</param>
        /// <param name="braidingDensity">Плотность оплётки, %</param>
        /// <param name="metal">Объект, содержащий информацию о материале оплётки</param>
        /// <returns>Массу оплётки, кг/км</returns>
        public static double CalculateWiresWieght(int spoolCounts, int wireCounts, double wireDiameter, double braidingAngle, double braidingDensity, Metal metal)
        {
            var braidingKoefficient = braidingDensity > 96 ? 1.0035 : 1.03;
            return (spoolCounts * wireCounts * Math.PI * Math.Pow((wireDiameter * 0.001), 2) * metal.Density20 * braidingKoefficient * 1000) / (4 * Math.Sin(braidingAngle * Math.PI / 180));
        }
    }
}
