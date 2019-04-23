using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestTickerline : BaseRequest
    {
        public RequestTickerline(string pairId) : base()
        {
            var sb = new StringBuilder("/api/v2/tickers/");

            queryUrl =  sb.Append(pairId.ToLower()).ToString();
        }
    }
}
