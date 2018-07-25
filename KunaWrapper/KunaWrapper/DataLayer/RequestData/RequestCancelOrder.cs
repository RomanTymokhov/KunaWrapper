using System;
using System.Collections.Generic;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestCancelOrder : BaseRequest
    {
        public RequestCancelOrder(SignParams sign, uint orderId) : base(sign)
        {
            RequestArgs["id"] = orderId.ToString();

            Url = "/api/v2/order/delete";

            GenerateRequest("POST");
        }

        public override string ToString() => BuildRequestData(RequestArgs);
    }
}
