namespace KunaWrapper.DataLayer.RequestData
{
    public class RequestVouchersList : BaseRequest
    {
        public RequestVouchersList(AuthData sign, byte page, short perPage) : base(sign)
        {
            queryUrl = "/api/v2/kuna_codes/list";

            arguments["page"] = page.ToString();
            arguments["per_page"] = perPage.ToString();

            GenerateAuthRequest("GET");
        }
    }
}
