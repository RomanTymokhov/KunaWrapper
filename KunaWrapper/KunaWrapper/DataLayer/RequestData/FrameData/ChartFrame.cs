using System;
using System.Collections.Generic;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData.FrameData
{
    public abstract class ChartFrame
    {
        internal ushort period;
        internal ushort select;

        public ChartFrame() { }
    }
}
