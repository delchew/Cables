using System;
using System.Text;
using Cables.Brands.SkabCables;
using Cables.Common;
using Cables.Materials;

namespace Cables.Brands.Common.NameBuilders
{
    public class SkabNameBuilder : ICableNameBuilder<Skab>, ICableMarkingBuilder<Skab>
    {
        private readonly StringBuilder _nameBuilder;

        public SkabNameBuilder(StringBuilder nameBuilder)
        {
            _nameBuilder = nameBuilder;
        }

        public SkabNameBuilder() : this(new StringBuilder())
        { }

        public string GetCableName(Skab cable)
        {
            _nameBuilder.Append(cable.VoltageType.GetDescription());

            if (cable.HasArmourTube)
                _nameBuilder.Append("K");
            else
                if (cable.HasBraidArmour)
                    _nameBuilder.Append("KГ");

            if (cable.CoverPolymerGroup == PolymerGroup.PUR)
                _nameBuilder.Append("У");

            _nameBuilder.Append(cable.FireProtectionClass.Designation);

            if (cable.CoverPolymerGroup == PolymerGroup.HFCompound ||
                cable.CoverPolymerGroup == PolymerGroup.PUR)
                _nameBuilder.Append("-ХЛ");
            var namePart = cable.HasIndividualFoilShields ? "э" : string.Empty;
            _nameBuilder.Append($" {cable.ElementsCount}х{(int)cable.TwistedElementType}{namePart}х");
            if (cable.InsulatedBillet.Billet.DeclaredAreaInSqrMm == null)
                throw new ArgumentException("Неверные данные! Площадь сечения для кабелей марки СКАБ должна быть обязательно указана!");
            namePart = CableCalculations.FormatConductorArea(cable.InsulatedBillet.Billet.DeclaredAreaInSqrMm ?? 0d);
            _nameBuilder.Append(namePart + "л");

            var braidMod = !cable.HasBraidShield ? "ф" : string.Empty;
            var fillMod = !cable.HasFilling ? "о" : string.Empty;
            var waterBlockMod = cable.HasWaterBlockingElements ? "в" : string.Empty;
            _nameBuilder.Append($" {braidMod}{fillMod}{waterBlockMod}");

            _nameBuilder.Append(cable.SparkSafety ? " Ex-i" : string.Empty);

            return _nameBuilder.ToString();
        }

        public string GetCableMarking(Skab cable)
        {
            var cableFullName = GetCableName(cable);
            return GetCableMarking(cableFullName, cable.TechConditions.Title);
        }

        public string GetCableMarking(string cableFullName, string techSpecificationsName)
        {
            return $"СПЕЦКАБЕЛЬ {cableFullName} {techSpecificationsName}";

        }
    }
}
