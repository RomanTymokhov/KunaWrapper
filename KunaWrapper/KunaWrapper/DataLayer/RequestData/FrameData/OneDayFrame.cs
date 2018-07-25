using System;
using System.Collections.Generic;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData.FrameData
{
    public class OneDayFrame : ChartFrame
    {
        public OneDayFrame(ushort limit) : base()
        {
            period = 1440;     //in minutes
            select = limit;
        }
    }
}
