namespace KunaWrapper.DataLayer.RequestData
{
    public class RequestWithdrawal : BaseRequest
    {
        public RequestWithdrawal(AuthData sign, string currencyId, string address, decimal amount) : base(sign)
        {
            queryUrl = "/api/v2/withdrawal";

            arguments["currency"] = currencyId;
            arguments["address"] = address;
            arguments["amount"] = amount.ToString(culture);

            GenerateAuthRequest("POST");
        }
    }
}
