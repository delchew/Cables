using System.Drawing;
using System.Collections.Generic;
using System.IO;
using Cables.Materials;
using System;
using Cables.Brands.SkabCables;

namespace Cables.Brands.Common.ColorsBuilders
{
    public class ScabColorsBuilder : ICableColorsBuilder<Skab>
    {
        private readonly TwistedCoreBuilder twistedCoreBuilder;
        private string polymerType;

        public ScabColorsBuilder()
        {
            twistedCoreBuilder = new TwistedCoreBuilder(new FileInfo(@"JsonDataFiles\twistInfo.json"));
        }

        public IList<Color[]> GetCableColorsSet (Skab skab)
        {
            polymerType = skab.InsulatedBillet.PolymerGroup == PolymerGroup.Rubber ? "Rubber" : "Plastic";
            var twistInfo = twistedCoreBuilder.GetTwistInfo(skab.ElementsCount);
            if (skab.HasIndividualFoilShields && (skab.TwistedElementType == TwistedElementType.pair || skab.TwistedElementType == TwistedElementType.triple))
                return GetIndividualShieldColors(skab.TwistedElementType, twistInfo);
            return GetColors(skab.TwistedElementType, twistInfo);
        }

        public IDictionary<Color, int> GetCableColorLengthsSet(Skab skabOrder)
        {
            var cableColorsSet = GetCableColorsSet(skabOrder);
            var lengthsSet = new Dictionary<Color, int>();
            foreach (var colorSet in cableColorsSet)
            {
                foreach (var color in colorSet)
                {
                    if (lengthsSet.ContainsKey(color))
                    {
                        lengthsSet[color]++;
                    }
                    else
                    {
                        lengthsSet.Add(color, 1);
                    }
                }
            }
            return lengthsSet;
        }

        private IList<Color[]> GetColors(TwistedElementType twistType, TwistInfo twistInfo)
        {
            string selectedSection;
            switch (twistType)
            {
                case TwistedElementType.single:
                    selectedSection = "SinglesColors";
                    break;
                case TwistedElementType.pair:
                    selectedSection = "PairsColors";
                    break;
                case TwistedElementType.triple:
                    selectedSection = "TriplesColors";
                    break;
                default: throw new ArgumentException("Кабели марки СКАБ не могут содержать изолированные элементы с таким типом скрутки!");
            }
            var jsonDataPath = $"$.SkabInsulationColors.{polymerType}.{selectedSection}";
            var cableColorsSet = colorsRepository.GetObjects<Color[]>(colorsDataFileInfo, jsonDataPath);
            if (twistInfo.QuantityElements <= cableColorsSet.Count)
            {
                var colors = new List<Color[]>();
                for (int i = 0; i < twistInfo.QuantityElements; i++)
                {
                    colors.Add(cableColorsSet[i]);
                }
                return colors;
            }
            return GetCountingMarkingColors(twistType, twistInfo);
        }

        private IList<Color[]> GetCountingMarkingColors(TwistedElementType twistType, TwistInfo twistInfo)
        {
            var colors = new List<Color[]>();
            var jsonDataPath = $"$.SkabInsulationColors.{polymerType}.CountingMarkingColors";
            var colorsDictionary = colorsRepository.GetObjects<TwistedElementType, CountingMarkingColors>(colorsDataFileInfo, jsonDataPath);
            var countingMarkingGolors = colorsDictionary[twistType];
            var pairsCount = 1;
            for (int i = 0; i < twistInfo.LayersElementsCount.Length; i++)
            {
                for (int j = 0; j < twistInfo.LayersElementsCount[i]; j++)
                {
                    switch (pairsCount)
                    {
                        case 1:
                            colors.Add(countingMarkingGolors.CountingColorsSet);
                            break;
                        case 2:
                            colors.Add(countingMarkingGolors.DirectingColorsSet);
                            break;
                        default:
                            colors.Add(countingMarkingGolors.OtherColorsSet);
                            break;
                    }
                    pairsCount++;
                }
                pairsCount = 1;
            }
            return colors;
        }

        private IList<Color[]> GetIndividualShieldColors(TwistedElementType twistType, TwistInfo twistInfo)
        {
            var colors = new List<Color[]>();
            var jsonDataPath = $"$.SkabInsulationColors.{polymerType}.IndividualColorsCombine";
            var colorsDictionary = colorsRepository.GetObjects<TwistedElementType, Color[]>(colorsDataFileInfo, jsonDataPath);
            var individualColorsCombine = colorsDictionary[twistType];
            for (int i = 0; i < twistInfo.QuantityElements; i++) colors.Add(individualColorsCombine);
            return colors;
        }
    }
}
