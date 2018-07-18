using KunaWrapper.DataLayer.Enums;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestHolderTrades : KunaRequest
    {
        public RequestHolderTrades(string pubKey, string secKey, long tonce, MarketPair pair) : base(pubKey, secKey, tonce)
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
