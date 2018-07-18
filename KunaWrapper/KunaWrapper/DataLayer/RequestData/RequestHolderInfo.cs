using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestHolderInfo : KunaRequest
    {
        public RequestHolderInfo(string pubKey, string secKey, long tonce) : base(pubKey, secKey, tonce)
        {
            Url = "/api/v2/members/me";

            GenerateRequest("GET");
        }

        public override string ToString()
        {
            var url = new StringBuilder(Url);
            url.AppendFormat("?{0}", BuildRequestData(RequestArgs));

            return url.ToString();
        }
    }
}
