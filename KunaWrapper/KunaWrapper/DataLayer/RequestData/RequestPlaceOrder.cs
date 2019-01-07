namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestPlaceOrder : BaseRequest
    {
        public RequestPlaceOrder(AuthData sign, string ordeType, string pairId, decimal volume, decimal coinPrice) : base(sign)
        {
            arguments["market"] = pairId;
            arguments["side"]   = ordeType;
            arguments["volume"] = volume.ToString(culture);
            arguments["price"]  = coinPrice.ToString(culture);

            queryUrl = "/api/v2/orders";

            GenerateRequest("POST");
        }
    }
}
