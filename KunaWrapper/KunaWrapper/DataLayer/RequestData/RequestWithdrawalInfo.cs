namespace KunaWrapper.DataLayer.RequestData
{
    public class RequestWithdrawalInfo : BaseRequest
    {
        public RequestWithdrawalInfo(AuthData sign, string withdrawalId) : base(sign)
        {
            queryUrl = "/api/v2/withdrawal";

            arguments["id"] = withdrawalId;

            GenerateAuthRequest("GET");
        }
    }
}
