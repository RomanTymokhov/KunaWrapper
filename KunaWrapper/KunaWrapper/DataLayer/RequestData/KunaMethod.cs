using System;
using System.Collections.Generic;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    public static class KunaMethod
    {
        //public methods

        public static string Timestamp { get { return "/api/v2/timestamp"; } }

        public static string Tickerline{ get { return "/api/v2/tickers/{0}"; } }

        public static string Orderbook { get { return "/api/v2/order_book?market={0}"; } }

        public static string Trades { get { return "/api/v2/trades?market={0}"; } }

        public static string Depth { get { return "/api/v2/depth?market={0}"; } }


        //private methods

        public static string KunaPerson{ get { return "/api/v2/members/me";} }

        public static string KunaPersonOrders { get { return "/api/v2/orders"; } }

        public static string KunaPersonTrades { get { return "/api/v2/trades/my"; } }

        public static string PlaceOrder { get { return "/api/v2/orders"; } }

        public static string CancelOrder { get { return "/api/v2/order/delete"; } }
    }
}
