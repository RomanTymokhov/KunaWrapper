using KunaWrapper.DataLayer.ReciveData;
using KunaWrapper.DataLayer.RequestData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KunaWrapper
{
    public class VouchersClient : BaseClient
    {
        public VouchersClient(string apiKey, string apiSec) : base(apiKey, apiSec) { }

        /// <summary>
        /// List of member's Kuna Code.
        /// Kuna Codes are returned sorted by created date desc.
        /// </summary>
        /// <param name="page">The ordinal number of the page in the sample</param>
        /// <param name="perPage">Quantity of elements per page</param>
        /// <returns>List(KuaCode)</returns>
        public async Task<List<KunaCode>> GetVouchersAsync(byte page, short perPage) =>
            await GetJsonAsync<List<KunaCode>>(new RequestVouchersList(authData, page, perPage));

        /// <summary>
        /// Create Kuna Code
        /// </summary>
        /// <param name="amount">amount of the creating code</param>
        /// <param name="currId">currency identifier</param>
        /// <param name="forUser">recipient of the code (system identifier)</param>
        /// <param name="nonRefund">non refoundable expirienc date ( in iso8601 )</param>
        /// <param name="comment">comment for the code</param>
        /// <param name="privComment">private comment - 255 symbols</param>
        /// <returns></returns>
        public async Task<KunaCode> CreateVoucherAsync(decimal amount, string currId, string forUser = "all",
            string nonRefund = null, string comment = null, string privComment = null) =>
                await PostJsonAsync<KunaCode>(new RequestCreateVoucher(authData, amount, currId, forUser, nonRefund, comment, privComment));

        /// <summary>
        /// Check kuna code by first 5 symbols of code
        /// </summary>
        /// <param name="codeString_firstFiveSimbols">code string first five simbols</param>
        /// <returns></returns>
        public async Task<KunaCode> CheckVoucherAsync(string codeString_firstFiveSimbols) =>
            await GetJsonAsync<KunaCode>(new RequestCheckVouher(authData, codeString_firstFiveSimbols));

        /// <summary>
        /// Redeem code
        /// </summary>
        /// <param name="codeString"> code string</param>
        /// <returns></returns>
        public async Task<KunaCode> RedeemVouherAsync(string codeString) =>
            await PutJsonAsync<KunaCode>(new RequestRedeemVouher(authData, codeString));
    }
}
