namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestChartData : BaseRequest
    {
        public RequestChartData(string pairId, string period, ushort limit) : base()
        {
            queryUrl = "/api/v2/k.json";

            arguments["market"] = pairId;
            arguments["period"] = period;
            arguments["limit"]  = limit.ToString();
        }
    }
}
