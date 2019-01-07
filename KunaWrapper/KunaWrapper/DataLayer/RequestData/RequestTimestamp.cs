namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestTimestamp : BaseRequest
    {
        public RequestTimestamp () : base()
        {
            queryUrl = "/api/v2/timestamp";
        }
    }
}
