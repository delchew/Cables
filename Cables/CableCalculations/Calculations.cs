using System;
using Cables.Materials;

namespace Cables.CableCalculations
{
    public static class Calculations
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
        public static double CalculateBraidingDensity(int spoolCounts, int wireCounts, double braidingStep, double braidingCoreDiameter, double wireDiameter) //Считает плотность оплётки, %
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
        /// <param name="tapeThickness">Толщина ленты, мкм</param>
        /// <returns>Расход ленты на 1км заготовки, кг</returns>
        public static double CalculateTapeWeight(Tape tape, double windingStep, double windingCoreDiameter, double tapeWidth, double tapeThickness)
        {
            double oneMeterTapeWeight = 0;
            for(int i = 0; i < tape.TapeLayers.Length; i++)
            {
                oneMeterTapeWeight += tape.TapeLayers[i].TapeMaterial.TapeMaterialDensity * tape.TapeLayers[i].Thickness * tapeWidth;
            }
            return oneMeterTapeWeight * CalculateTapeLength(windingStep, windingCoreDiameter, tapeThickness) / 1000000;
        }

        /// <summary>
        /// Рассчитывает максимальную длину кабеля заданного диаметра, которая влезет на барабан с заданными параметрами, м (округлённое до ближайшего целого)
        /// </summary>
        /// <param name="reelDiameter">Диаметр барабана, мм</param>
        /// <param name="barrelDiameter">Диаметр живота барабана, мм</param>
        /// <param name="lengthBetweenFlanges">Расстояние между щёками барабана, мм</param>
        /// <param name="deltaToEdge">Расстояние от края намотки до края барабана, мм</param>
        /// <param name="cableDiameter">Диаметр наматываемой заготовки, мм</param>
        /// <returns>Максимальная длина кабеля заданного диаметра, которая влезет на барабан с заданными параметрами, м (округлённая до ближайшего целого)</returns>
        public static int CalculateMaxCableLengthOnReel(double reelDiameter, double barrelDiameter, double lengthBetweenFlanges, double deltaToEdge, double cableDiameter)
        {
            return (int)Math.Round(Math.PI * lengthBetweenFlanges * (Math.Pow((reelDiameter - 2 * deltaToEdge), 2) - barrelDiameter * barrelDiameter) / (4000 * cableDiameter * cableDiameter));
        }

        /// <summary>
        /// Возвращает рассчётный диаметр скручиваемого изделия, мм
        /// </summary>
        /// <param name="elementType">Тип скручиваемого элемента</param>
        /// <param name="singleElementDiameter">Диаметр скручиваемого элемента, мм</param>
        /// <param name="layingKoefficient">Коэффициент укладки</param>
        /// <returns>Рассчётный диаметр скручиваемого изделия, мм/returns>
        public static double TwistedElementsCoreDiameter(TwistedElementType elementType, double singleElementDiameter, double layingKoefficient)
        {
            switch(elementType)
            {
                case (TwistedElementType.triple):
                    return singleElementDiameter * layingKoefficient * 2;
                case (TwistedElementType.four):
                    return singleElementDiameter * layingKoefficient * 2.2;
                default:
                    return singleElementDiameter * layingKoefficient * 1.6;
            }
        }
    }
}