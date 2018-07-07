using System;
using System.Collections.Generic;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    public static class KunaMethods
    {
        //public methods

        public static string Timestamp { get { return "/api/v2/timestamp"; } }

        public static string Orderbook { get { return "/api/v2/order_book?market={0}"; } }

        public static string Tickerline{ get { return "/api/v2/tickers/{0}"; } }

        public static string Trades { get { return "/api/v2/trades?market={0}"; } }

        public static string Depth { get { return "/api/v2/depth?market={0}"; } }


        //private methods

        public static string KunaPerson{ get { return "api/v2/members/me";} }

        //public static string Orders { get { return "/api/v2/orders?market={0}"; } }
    }
}
