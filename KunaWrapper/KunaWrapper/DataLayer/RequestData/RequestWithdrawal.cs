namespace KunaWrapper.DataLayer.RequestData
{
    public class RequestWithdrawal : BaseRequest
    {
        public RequestWithdrawal(AuthData sign, string currencyId, string address, decimal amount) : base(sign)
        {
            queryUrl = "/api/v2/withdrawal";

            arguments["address"]  = address;
            arguments["currency"] = currencyId.ToLower();
            arguments["amount"]   = amount.ToString(culture);

            GenerateAuthRequest("POST");
        }
    }
}
