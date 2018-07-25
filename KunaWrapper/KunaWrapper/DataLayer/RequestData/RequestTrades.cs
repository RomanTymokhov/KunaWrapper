using KunaWrapper.DataLayer.Enums;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestTrades : BaseRequest
    {
        public RequestTrades(MarketPair pair, ushort limit) : base()
        {
            Url = "/api/v2/trades";

            RequestArgs["market"] = pair.ToString();
            RequestArgs["limit"] = limit.ToString();
        }

        public override string ToString()
        {
            var url = new StringBuilder(Url);
            url.AppendFormat("?{0}", BuildRequestData(RequestArgs));

            return url.ToString();
        }
    }
}
