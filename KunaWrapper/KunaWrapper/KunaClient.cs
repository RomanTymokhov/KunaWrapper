using KunaWrapper.DataLayer.ReciveData;
using KunaWrapper.DataLayer.RequestData;
using KunaWrapper.DataLayer.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System;

namespace KunaWrapper
{
    public class KunaClient
    {
        private readonly HttpClient httpClient;

        private const string baseAddress = "https://kuna.io";

        private readonly string publicKey;
        private readonly string secretKey;

        public KunaClient(string pubKey, string secKey)
        {
            publicKey = pubKey;
            secretKey = secKey;

            httpClient = new HttpClient { BaseAddress = new Uri(baseAddress)};
        }

        protected async Task<T> GetJsonAsync<T>(KunaRequest request)
        {
            var response = await httpClient.GetAsync(request.ToString()).ConfigureAwait(false);

            var json = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();         // throw if web request failed
            
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(json));
        }

        protected async Task<T> PostJsonAsync<T>(KunaRequest request)
        {
            var response = await httpClient.PostAsync(request.Url,
                new StringContent(request.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded")).ConfigureAwait(false);

            var json = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();         // throw if web request failed
            
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(json));
        }

        #region Private Methods

        public async Task<Holder> GetHolderInfoAsync()
        {
            return await GetJsonAsync<Holder>(new RequestHolderInfo(publicKey, secretKey, DateTimeOffset.Now.ToUnixTimeMilliseconds()));
        }

        public async Task<List<Order>> GetHolderOrdersAsync(MarketPair pair)
        {
            return await GetJsonAsync<List<Order>>(new RequestHolderOrders(publicKey, secretKey, DateTimeOffset.Now.ToUnixTimeMilliseconds(), pair));
        }

        public async Task<List<Trade>> GetHolderTradesAsync(MarketPair pair)
        {
            return await GetJsonAsync<List<Trade>>(new RequestHolderTrades(publicKey, secretKey, DateTimeOffset.Now.ToUnixTimeMilliseconds(), pair));
        }

        public async Task<Order> PlaceOrderAsync(OrderSide orderSide, decimal volume, MarketPair pair, decimal coinPrice)
        {            
            return await PostJsonAsync<Order>(new RequestPlaceOrder(publicKey, secretKey, DateTimeOffset.Now.ToUnixTimeMilliseconds(), orderSide, volume, pair, coinPrice));
        }

        public async Task<Order> CancelOrderAsync(uint orderId)
        {
            return await PostJsonAsync<Order>(new RequestCancelOrder(publicKey, secretKey, DateTimeOffset.Now.ToUnixTimeMilliseconds(), orderId));
        }

        #endregion

        #region Public Methods

        public  async Task<long> GetTimestampAsync()
        {
            return await GetJsonAsync<long>(new RequestTimestamp());
        }

        public async Task<TickerLine> GetTickerLineAsync(MarketPair pair)
        {
            return await GetJsonAsync<TickerLine>(new RequestTickerline(pair));
        }

        public async Task<OrderBook> GetOrderBookAsync(MarketPair pair)
        {
            return await GetJsonAsync<OrderBook>(new RequestOrderbook(pair));
        }

        public async Task<List<Trade>> GetTradesAsync(MarketPair pair)
        {
            return await GetJsonAsync<List<Trade>>(new RequestTrades(pair));
        }

        public async Task<Depth> GetDepthAsync(MarketPair pair)
        {
            return await GetJsonAsync<Depth>(new RequestDepth(pair));
        }

        #endregion
    }
}
