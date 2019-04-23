using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    public class RequestCheckVouher : BaseRequest
    {
        public RequestCheckVouher(AuthData sign, string code) : base(sign)
        {
            var sb = new StringBuilder("/api/v2/kuna_codes/check/");

            queryUrl = sb.Append(code).ToString();
        }
    }
}
