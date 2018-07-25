using System;
using System.Collections.Generic;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData.FrameData
{
    public class OneHourFrame : ChartFrame
    {
        public OneHourFrame(ushort limit) : base()
        {
            period = 60;     //in minutes
            select = limit;
        }
    }
}
