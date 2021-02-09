using System.ComponentModel;

namespace Cables.Common
{
    public enum PowerWiresColorScheme
    {
        [Description("(N)")]
        N = 1,

        [Description("(PE)")]
        PE = 2,

        [Description("(PE, N)")]
        PEN = 3,

        [Description("")]
        none = 4
    }
}
