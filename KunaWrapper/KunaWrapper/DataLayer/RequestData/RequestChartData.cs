using System.Text;
using KunaWrapper.DataLayer.Enums;
using KunaWrapper.DataLayer.RequestData.FrameData;
using System;
using System.Collections.Generic;

namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestChartData : BaseRequest
    {
        public RequestChartData(MarketPair pair, ChartFrame frame) : base()
        {
            Url = "/api/v2/k.json";

            RequestArgs["market"] = pair.ToString();
            RequestArgs["period"] = frame.period.ToString();
            RequestArgs["limit"] = frame.select.ToString();
        }

        public override string ToString()
        {
            var url = new StringBuilder(Url);
            url.AppendFormat("?{0}", BuildRequestData(RequestArgs));

            return url.ToString();
        }
    }
}
