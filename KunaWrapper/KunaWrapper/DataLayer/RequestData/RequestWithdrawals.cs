namespace KunaWrapper.DataLayer.RequestData
{
    public class RequestWithdrawals : BaseRequest
    {
        public RequestWithdrawals(AuthData sign, ushort page, ushort perPage, string currencyId) : base(sign)
        {
            queryUrl = "/api/v2/withdrawals";

            arguments["page"] = page.ToString();
            arguments["per_page"] = perPage.ToString();

            if (currencyId != null) arguments["currency"] = currencyId;

            GenerateAuthRequest("GET");
        }
    }
}
