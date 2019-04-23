namespace KunaWrapper.DataLayer.RequestData
{
    public class RequestRedeemVouher : BaseRequest
    {
        public RequestRedeemVouher(AuthData sign, string codeString) : base(sign)
        {
            queryUrl = "/api/v2/kuna_codes/redeem";

            arguments["code"] = codeString;

            GenerateAuthRequest("PUT");
        }
    }
}
