namespace KunaWrapper.DataLayer.RequestData
{
    public class RequestCreateVoucher : BaseRequest
    {
        public RequestCreateVoucher(AuthData sign, decimal amount, string currId, string forUser, 
                                    string nonRefund, string comment, string privComment) : base(sign)
        {
            queryUrl = "/api/v2/kuna_codes/issue";

            arguments["currency"] = currId;
            arguments["addressee"] = forUser;
            arguments["amount"] = amount.ToString(culture);

            if (nonRefund != null)   arguments["non_refundable_before"] = nonRefund;
            if (privComment != null) arguments["private_comment"] = privComment;
            if (comment != null)     arguments["comment"] = comment;

            GenerateRequest("POST");
        }
    }
}
