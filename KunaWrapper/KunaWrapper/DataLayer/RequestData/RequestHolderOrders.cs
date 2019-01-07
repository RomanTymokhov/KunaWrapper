namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestHolderOrders : BaseRequest
    {
        public RequestHolderOrders(AuthData sign, string pairId) : base(sign)
        {
            queryUrl = "/api/v2/orders";

            arguments["market"] = pairId;

            GenerateRequest("GET");
        }
    }
}
