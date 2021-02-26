using System;
using System.ComponentModel;

namespace Cables.Common
{
    [Flags]
    public enum CableColor
    {
        [Description("Натуральный")]
        natural = 0,

        [Description("Красный")]
        red = 1,

        [Description("Чёрный")]
        black = 2,

        [Description("Синий")]
        blue = 4,

        [Description("Коричневый")]
        brown = 8,

        [Description("Жёлтый")]
        yellow = 16,

        [Description("Белый")]
        white = 32,

        [Description("Зелёный")]
        green = 64,

        [Description("Оранжевый")]
        orange = 128,

        [Description("Серый")]
        grey = 256,

        [Description("Фиолетовый")]
        violet = 512
    }
}
