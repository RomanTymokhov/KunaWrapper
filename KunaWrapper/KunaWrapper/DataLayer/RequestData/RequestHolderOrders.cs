namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestHolderOrders : BaseRequest
    {
        public RequestHolderOrders(AuthData sign, string pairId, string state) : base(sign)
        {
            queryUrl = "/api/v2/orders";

            arguments["market"] = pairId;
            arguments["state"] = state;

            GenerateAuthRequest("GET");
        }
    }
}
