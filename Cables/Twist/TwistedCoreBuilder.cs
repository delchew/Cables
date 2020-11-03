using Cables.CableElements;
using Cables.Materials;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cables
{
    public class TwistedCoreBuilder
    {
        private readonly ICollection<TwistInfo> twistInfoList;
        public readonly int MaxTwistedElementsCount;

        public TwistedCoreBuilder(ICollection<TwistInfo> twistInfoList)
        {
            this.twistInfoList = twistInfoList;
            MaxTwistedElementsCount = twistInfoList.Last().QuantityElements;
        }

        private readonly Dictionary<TwistedElementType, Func<double, double, double>> CalcCoreDiametersMethods =
            new Dictionary<TwistedElementType, Func<double, double, double>>
            {
                { TwistedElementType.single, (singleElementDiameter, twistKoefficient) => singleElementDiameter * twistKoefficient },
                { TwistedElementType.pair, (singleElementDiameter, twistKoefficient) => singleElementDiameter * twistKoefficient * 1.6 },
                { TwistedElementType.triple, (singleElementDiameter, twistKoefficient) => singleElementDiameter * twistKoefficient * 2},
                { TwistedElementType.four, (singleElementDiameter, twistKoefficient) => singleElementDiameter * twistKoefficient * 2.2 }
            };

        public TwistedCore GetTwistedCore(int twistedElementsCount, ICableElement preform, Tape? tape = null, Thread? thread = null)
        {
            var twistInfo = GetTwistInfo(twistedElementsCount);
            var twistedElementType = DefineTwistedCoreType(twistedElementsCount);
            var twistKoefficient = GetTwistKoefficient(twistedElementsCount);

            double diameter = 0;
            if (preform is TwistedCore core)
            {
                if (core.TwistedElementType == TwistedElementType.core)
                    diameter = core.Diameter * twistKoefficient * 0.9;
                else
                    diameter = CalcCoreDiametersMethods[twistedElementType].Invoke(core.Preform.Diameter, twistKoefficient);
            }
            else
                diameter = CalcCoreDiametersMethods[twistedElementType].Invoke(preform.Diameter, twistKoefficient);

            var twistStep = GetTwistStep(preform, diameter);
            var twistedCore = new TwistedCore()
            {
                Preform = preform,
                TwistInfo = twistInfo,
                TwistedElementType = twistedElementType,
                Tape = tape,
                Thread = thread,
                Diameter = diameter,
                TwistStep = twistStep
            };
            return twistedCore;
        }

        public double GetTwistedCoreDiameterBySingleElement(int twistedElementsCount, double singleElementDiameter, TwistedElementType elementType)
        {
            if (elementType == TwistedElementType.core)
                throw new ArgumentException("Метод не работает с типом скрученного сердечника Core!");
            CheckInputTwistedElementsCount(twistedElementsCount);
            var twistKoefficient = GetTwistKoefficient(twistedElementsCount);
            return CalcCoreDiametersMethods[elementType].Invoke(singleElementDiameter, twistKoefficient);
        }

        public double GetTwistKoefficient(int twistedElementsCount)
        {
            return GetTwistInfo(twistedElementsCount).TwistCoefficient;
        }

        public int[] GetLayersElementsCount(int twistedElementsCount)
        {
            return GetTwistInfo(twistedElementsCount).LayersElementsCount;
        }

        public TwistInfo GetTwistInfo(int twistedElementsCount)
        {
            CheckInputTwistedElementsCount(twistedElementsCount);
            return twistInfoList.Where(info => info.QuantityElements == twistedElementsCount).First();
        }

        public double GetTwistStep(ICableElement singleTwistedElement, double twistedCoreDiameter)
        {
            return (singleTwistedElement is ConductingCore || singleTwistedElement is ExtrusionElement) ?
                twistedCoreDiameter * 16 : twistedCoreDiameter * 18;
        }

        public double GetTwistStep(TwistedElementType singleTwistedElementType, double twistedCoreDiameter)
        {
            if (singleTwistedElementType == TwistedElementType.single) return twistedCoreDiameter * 16;
            return twistedCoreDiameter * 18;
        }

        private TwistedElementType DefineTwistedCoreType(int twistedElementsCount)
        {
            CheckInputTwistedElementsCount(twistedElementsCount);
            switch (twistedElementsCount)
            {
                case 2: return TwistedElementType.pair;
                case 3: return TwistedElementType.triple;
                case 4: return TwistedElementType.four;
                default: return TwistedElementType.core;
            }
        }

        private void CheckInputTwistedElementsCount(int twistedElementsCount)
        {
            if (twistedElementsCount < 2)
                throw new ArgumentException("Ошибочные данные! Нельзя скрутить число элементов меньше 2!");
            if (twistedElementsCount > MaxTwistedElementsCount)
                throw new ArgumentException("Нет данных данных для такого числа элементов!" +
                $"Максимальное число - {MaxTwistedElementsCount}");
        }
    }
}
