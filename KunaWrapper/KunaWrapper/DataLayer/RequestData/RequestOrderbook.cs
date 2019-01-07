namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestOrderbook : BaseRequest
    {
        public RequestOrderbook(string pairId) : base()
        {
            queryUrl = "/api/v2/order_book";

            arguments["market"] = pairId;
        }
    }
}
