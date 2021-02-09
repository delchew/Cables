using Cables.Brands.KunrsCables;
using Cables.Materials;
using System.Text;
using System.Collections.Generic;
using Cables.Common;
using System;

namespace Cables.Brands.Common.NameBuilders
{
    public class KunrsNameBuider : ICableNameBuilder<Kunrs>, ICableMarkingBuilder<Kunrs>
    {
        private readonly StringBuilder _nameBuilder;
        private readonly Dictionary<PolymerGroup, string> _polymerNamePartsDict;

        public KunrsNameBuider()
        {
            _nameBuilder = new StringBuilder("КУНРС ");

            _polymerNamePartsDict = new Dictionary<PolymerGroup, string>
            {
                { PolymerGroup.PVC_LS, "В" },
                { PolymerGroup.HFCompound, "П" },
                { PolymerGroup.PUR, "У" }
            };
        }

        public string GetCableName(Kunrs cable)
        {
            _nameBuilder.Append(cable.HasFoilShield ? "Э" : string.Empty);
            var namePart = _polymerNamePartsDict[cable.CoverPolymerGroup];
            _nameBuilder.Append(cable.HasArmourTube ? $"{namePart}K" : string.Empty);
            _nameBuilder.Append(namePart);
            _nameBuilder.Append(cable.FireProtectionClass.Designation);
            if (cable.InsulatedBillet.Billet.DeclaredAreaInSqrMm == null)
                throw new ArgumentException("Неверные данные! Площадь сечения для кабелей марки СКАБ должна быть обязательно указана!");
            namePart = CableCalculations.FormatConductorArea(cable.InsulatedBillet.Billet.DeclaredAreaInSqrMm ?? 0d);
            _nameBuilder.Append($" {cable.ElementsCount}х{namePart}");
            _nameBuilder.Append($" {cable.PowerColorScheme.GetDescription()}");
            return _nameBuilder.ToString();
        }

        public string GetCableMarking(string cableFullName, string techSpecificationsName)
        {
            return $"СПЕЦКАБЕЛЬ {cableFullName} 450/750 {techSpecificationsName}";
        }

        public string GetCableMarking(Kunrs cable)
        {
            var cableFullName = GetCableName(cable);
            return GetCableMarking(cableFullName, cable.TechnicalSpecifications);
        }
    }
}
