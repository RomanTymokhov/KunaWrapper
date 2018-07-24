namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestTimestamp : KunaRequest
    {
        public RequestTimestamp () : base()
        {
            Url = "/api/v2/timestamp";
        }

        public override string ToString() => Url;
    }
}
