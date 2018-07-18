using KunaWrapper.DataLayer.Enums;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestDepth : KunaRequest
    {
        public RequestDepth(MarketPair pair) : base()
        {
            Url = "/api/v2/depth";

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
