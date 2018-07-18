using KunaWrapper.DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestPlaceOrder : KunaRequest
    {
        public RequestPlaceOrder(string pubKey, string secKey, long tonce, OrderSide orderSide, 
                                     decimal volume, MarketPair pair, decimal coinPrice) : base(pubKey, secKey, tonce)
        {
            RequestArgs["side"] = orderSide.ToString();
            RequestArgs["volume"] = volume.ToString(CultureInfo.InvariantCulture);
            RequestArgs["market"] = pair.ToString();
            RequestArgs["price"] = coinPrice.ToString(CultureInfo.InvariantCulture);

            Url = "/api/v2/orders";

            GenerateRequest("POST");
        }

        public override string ToString()
        {
            return BuildRequestData(RequestArgs);
        }
    }
}
