namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestHolderInfo : BaseRequest
    {
        public RequestHolderInfo(AuthData sign) : base(sign)
        {
            queryUrl = "/api/v2/members/me";

            GenerateAuthRequest("GET");
        }
    }
}
