using System;

namespace Cables
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
        /// <returns>Максимальная длина кабеля заданного диаметра, которая влезет на барабан с заданными параметрами, м (округлённая до ближайшего целого)</returns>
        public static int CalculateMaxCableLengthOnReel(int reelDiameter, int barrelDiameter, int lengthBetweenFlanges, int deltaToEdge, double cableDiameter)
        {
            return (int)Math.Round(Math.PI * lengthBetweenFlanges * (Math.Pow(reelDiameter - 2 * deltaToEdge, 2) - barrelDiameter * barrelDiameter) / (4000 * cableDiameter * cableDiameter));
        }
    }
}