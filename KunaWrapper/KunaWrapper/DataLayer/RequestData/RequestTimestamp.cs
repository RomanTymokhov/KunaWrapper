namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestTimestamp : BaseRequest
    {
        public RequestTimestamp () : base()
        {
            Url = "/api/v2/timestamp";
        }

        public override string ToString() => Url;
    }
}
