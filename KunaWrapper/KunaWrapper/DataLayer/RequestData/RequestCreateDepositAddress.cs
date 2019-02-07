using System;
using System.Collections.Generic;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    public class RequestCreateDepositAddress : BaseRequest
    {
        public RequestCreateDepositAddress(AuthData sign, string currencyId) : base(sign)
        {
            queryUrl = "/api/v2/deposit_address";

            arguments["currency"] = currencyId;

            GenerateRequest("GET");
        }
    }
}
