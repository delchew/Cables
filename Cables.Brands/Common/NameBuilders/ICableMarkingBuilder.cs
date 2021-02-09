namespace Cables.Brands.Common.NameBuilders
{
    public interface ICableMarkingBuilder<T> where T : Cable
    {
        string GetCableMarking(T cable);

        string GetCableMarking(string cableFullName, string techSpecificationsName);
    }
}
