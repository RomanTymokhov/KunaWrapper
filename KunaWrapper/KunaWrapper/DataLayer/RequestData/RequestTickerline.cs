namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestTickerline : BaseRequest
    {
        public RequestTickerline(string pairId) : base()
        {
            queryUrl = "/api/v2/tickers/" + pairId;
        }
    }
}
