namespace KunaWrapper.DataLayer
{
    public static class ServiceTypes
    {
        //------------ Order Type ----------//
        public const string _buy  = "buy";
        public const string _sell = "sell";

        //------------ Order Side ----------//
        public const string _bid = "bid";
        public const string _ask = "ask";

        //------------ Order Side ----------//
        public const string _wait   = "wait";
        public const string _cancel = "cancel";
        public const string _done   = "done";

        //------------ Market Type ----------//
        public const string _limit  = "limit";
        public const string _market = "market";

        //------------ Frame Period ----------//
        public const string _15_min = "15";
        public const string _30_min = "30";
        public const string _1_hour = "60";
        public const string _4_hour = "240";
        public const string _1_day  = "1440";
        public const string _1_week = "10080";
    }
}
