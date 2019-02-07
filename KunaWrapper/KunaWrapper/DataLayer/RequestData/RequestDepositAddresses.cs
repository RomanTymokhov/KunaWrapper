using System;
using System.Collections.Generic;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    public class RequestDepositAddresses : BaseRequest
    {
        public RequestDepositAddresses(AuthData sign, string currencyId) : base(sign)
        {
            queryUrl = "/api/v2/deposit_addresses";

            arguments["currency"] = currencyId;

            GenerateRequest("GET");
        }
    }
}
