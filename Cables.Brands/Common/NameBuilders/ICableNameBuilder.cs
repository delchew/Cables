namespace Cables.Brands.Common.NameBuilders
{
    public interface ICableNameBuilder<T> where T : Cable
    {
        string GetCableName(T cable);
    }
}
