using System;
using System.Collections.Generic;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData.FrameData
{
    public class OneWeekFrame : ChartFrame
    {
        public OneWeekFrame(ushort limit) : base()
        {
            period = 10080;     //in minutes
            select = limit;
        }
    }
}
