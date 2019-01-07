namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestTradeHistory : BaseRequest
    {
        public RequestTradeHistory(string pairId, ushort limit) : base()
        {
            queryUrl = "/api/v2/trades";

            arguments["market"] = pairId;
            arguments["limit"]  = limit.ToString();
        }
    }
}
