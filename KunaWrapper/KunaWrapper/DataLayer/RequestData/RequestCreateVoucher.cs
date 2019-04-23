namespace KunaWrapper.DataLayer.RequestData
{
    public class RequestCreateVoucher : BaseRequest
    {
        public RequestCreateVoucher(AuthData sign, decimal amount, string currId, string forUser = "all", 
                                    string nonRefund = null, string comment = null , string privComment = null) : base(sign)
        {
            queryUrl = "/api/v2/kuna_codes/issue";

            arguments["amount"] = amount.ToString(culture);
            arguments["currency"] = currId;
            arguments["addressee"] = forUser;

            if (nonRefund != null)   arguments["non_refundable_before"] = nonRefund;
            if (privComment != null) arguments["private_comment"] = privComment;
            if (comment != null)     arguments["comment"] = comment;

            GenerateRequest("POST");
        }
    }
}
