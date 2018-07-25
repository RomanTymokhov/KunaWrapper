using KunaWrapper.DataLayer.Enums;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestHolderOrders : BaseRequest
    {
        public RequestHolderOrders(SignParams sign, MarketPair pair) : base(sign)
        {
            RequestArgs["market"] = pair.ToString();

            Url = "/api/v2/orders";

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
