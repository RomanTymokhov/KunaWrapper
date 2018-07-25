using System;
using System.Collections.Generic;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData.FrameData
{
    public class FourHourFrame : ChartFrame
    {
        public FourHourFrame(ushort limit) : base()
        {
            period = 240;     //in minutes
            select = limit;
        }
    }
}
