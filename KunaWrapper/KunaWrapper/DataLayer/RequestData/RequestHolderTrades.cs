namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestHolderTrades : BaseRequest
    {
        public RequestHolderTrades(AuthData sign, string pairId) : base(sign)
        {
            arguments["market"] = pairId;

            queryUrl = "/api/v2/trades/my";

            GenerateRequest("GET");
        }
    }
}
