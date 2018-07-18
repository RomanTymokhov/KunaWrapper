using KunaWrapper.DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestObjectPlaceOrder : RequestObject
    {
        public RequestObjectPlaceOrder(string pubKey, string secKey, long tonce, OrderSide orderSide, 
                                     decimal volume, MarketPair pair, decimal coinPrice) : base(pubKey, secKey, tonce)
        {
            RequestArgs["side"] = orderSide.ToString();
            RequestArgs["volume"] = volume.ToString(CultureInfo.InvariantCulture);
            RequestArgs["market"] = pair.ToString();
            RequestArgs["price"] = coinPrice.ToString(CultureInfo.InvariantCulture);

            GenerateRequest("POST", KunaMethod.PlaceOrder);
        }
    }
}
