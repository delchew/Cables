using System;

namespace Cables
{
    public delegate void QuantityElementsChangedEventHandler(object sender, QuantityElementsChangedEventArgs e);
    public class QuantityElementsChangedEventArgs : EventArgs
    {
        public TwistInfo TwistInfo { get; }
        public QuantityElementsChangedEventArgs(TwistInfo twistInfo)
        {
            TwistInfo = twistInfo;
        }
    }
}
