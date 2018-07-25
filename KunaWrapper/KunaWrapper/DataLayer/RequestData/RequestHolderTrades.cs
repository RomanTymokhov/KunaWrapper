using KunaWrapper.DataLayer.Enums;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestHolderTrades : BaseRequest
    {
        public RequestHolderTrades(SignParams sign, MarketPair pair) : base(sign)
        {
            RequestArgs["market"] = pair.ToString();

            Url = "/api/v2/trades/my";

            GenerateRequest("GET");
        }

        public override string ToString()
        {
            var url = new StringBuilder(Url);
            url.AppendFormat("?{0}", BuildRequestData(RequestArgs));

            return url.ToString();
        }
    }
}
