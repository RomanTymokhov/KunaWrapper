using KunaWrapper.DataLayer.Enums;
using KunaWrapper.DataLayer.ReciveData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KunaWrapper
{
    public class KunaClient
    {
        private HttpClient httpClient;

        private string publicKey;
        private string secretKey;

        private const string baseAddress = "https://kuna.io/";

        public KunaClient(string pubKey, string secKey)
        {
            publicKey = pubKey;
            secretKey = secKey;

            httpClient = new HttpClient { BaseAddress = new Uri(baseAddress)};
        }

        protected async Task<T> GetJsonAsync<T>(string requestUri)
        {
            var response = await httpClient.GetAsync(requestUri).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();         // throw if web request failed

            var json = await response.Content.ReadAsStringAsync();
            
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(json));
        }

        #region Public Methods

        public async Task<int> GetTimestampAsync()
        {
            const string url = "/api/v2/timestamp";

            return await GetJsonAsync<int>(url);
        }

        public async Task<TickerLine> GetTickerLineAsync(MarketPair pair)
        {
            string url = "/api/v2/tickers/" + pair.ToString();

            return await GetJsonAsync<TickerLine>(url);
        }

        public async Task<OrderBook> GetOrderBookAsync(MarketPair pair)
        {
            // get request uri
            var sb = new StringBuilder();
            sb.AppendFormat("/api/v2/order_book?market={0}", pair.ToString());

            string url = sb.ToString();

            return await GetJsonAsync<OrderBook>(url);
        }

        public async Task<List<Trade>> GetTradesAsync(MarketPair pair)
        {
            // get request uri
            var sb = new StringBuilder();
            sb.AppendFormat("/api/v2/trades?market={0}", pair.ToString());

            string url = sb.ToString();

            return await GetJsonAsync<List<Trade>>(url);
        }

        public async Task<Depth> GetDepthAsync(MarketPair pair)
        {
            // get request uri
            var sb = new StringBuilder();
            sb.AppendFormat("/api/v2/depth?market={0}", pair.ToString());

            string url = sb.ToString();

            return await GetJsonAsync<Depth>(url);
        }

        #endregion
    }
}
