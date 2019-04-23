namespace KunaWrapper.DataLayer.RequestData
{
    public class RequestAllDeposits : BaseRequest
    {
        public RequestAllDeposits(AuthData sign, ushort page, ushort perPage, bool full, string currencyId, string depositAddressesIds, string payInIds) : base(sign)
        {
            queryUrl = "/api/v2/deposits";

            arguments["page"] = page.ToString();
            arguments["per_page"] = perPage.ToString();
            arguments["full"] = full.ToString();

            if (currencyId != null) arguments["currency"] = currencyId;
            if (depositAddressesIds != null) arguments["deposit_address_ids"] = depositAddressesIds;
            if (payInIds != null) arguments["pay_in_ids"] = payInIds;

            GenerateAuthRequest("GET");
        }
    }
}
