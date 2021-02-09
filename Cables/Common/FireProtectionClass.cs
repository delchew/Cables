namespace Cables.Common
{
    public struct FireProtectionClass
    {
        public const string GOST = "ГОСТ 31565-2012";

        public int Id { get; set; }

        public string ProtectionClass { get; set; }

        public string Designation { get; set; }
    }
}
