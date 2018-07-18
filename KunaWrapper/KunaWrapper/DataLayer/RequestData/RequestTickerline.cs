using KunaWrapper.DataLayer.Enums;

namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestTickerline : KunaRequest
    {
        public RequestTickerline(MarketPair pair) : base()
        {
            Url = "/api/v2/tickers/" + pair.ToString();
        }

        public override string ToString()
        {
            return Url;
        }
    }
}
