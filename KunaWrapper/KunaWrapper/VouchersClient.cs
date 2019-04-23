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
        public async Task<List<KunaCode>> GetKunaCodesAsync(byte page, short perPage) =>
            await GetJsonAsync<List<KunaCode>>(new RequestVouchersList(authData, page, perPage));
    }
}
