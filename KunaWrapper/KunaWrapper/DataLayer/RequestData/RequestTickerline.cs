using KunaWrapper.DataLayer.Enums;

namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestTickerline : BaseRequest
    {
        public RequestTickerline(MarketPair pair) : base()
        {
            Url = "/api/v2/tickers/" + pair.ToString();
        }

        public override string ToString() => Url;
    }
}
