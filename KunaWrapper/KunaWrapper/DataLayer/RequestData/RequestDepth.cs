namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestDepth : BaseRequest
    {
        public RequestDepth(string pairId) : base()
        {
            queryUrl = "/api/v2/depth";

            arguments["market"] = pairId;
        }
    }
}
