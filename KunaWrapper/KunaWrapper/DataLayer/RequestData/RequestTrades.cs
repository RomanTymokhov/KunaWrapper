using KunaWrapper.DataLayer.Enums;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestTrades : KunaRequest
    {
        public RequestTrades(MarketPair pair) : base()
        {
            Url = "/api/v2/trades";

            RequestArgs["market"] = pair.ToString();
        }

        public override string ToString()
        {
            var url = new StringBuilder(Url);
            url.AppendFormat("?{0}", BuildRequestData(RequestArgs));

            return url.ToString();
        }
    }
}
