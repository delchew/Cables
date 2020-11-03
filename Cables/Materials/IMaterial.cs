namespace Cables.Materials
{
    public interface IMaterial
    {
        /// <summary>
        /// Название материала 
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Плотность в кг/м³, при 20°С
        /// </summary>
        int Density20 { get; set; }
    }
}
