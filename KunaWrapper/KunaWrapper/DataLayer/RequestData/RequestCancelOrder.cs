namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestCancelOrder : BaseRequest
    {
        public RequestCancelOrder(AuthData sign, uint orderId) : base(sign)
        {
            queryUrl = "/api/v2/order/delete";

            arguments["id"] = orderId.ToString();

            GenerateAuthRequest("POST");
        }
    }
}
