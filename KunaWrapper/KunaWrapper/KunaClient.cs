using KunaWrapper.DataLayer.KunaException;
using KunaWrapper.DataLayer.ReciveData;
using KunaWrapper.DataLayer.RequestData;
using KunaWrapper.DataLayer.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System;
using KunaWrapper.DataLayer.RequestData.FrameData;

namespace KunaWrapper
{
    public class KunaClient : IDisposable
    {
        private readonly HttpClient httpClient;

        private const string baseAddress = "https://kuna.io";

        private readonly SignParams signParams;


        public KunaClient(string pubKey, string secKey)
        {
            signParams = new SignParams(pubKey, secKey);

            httpClient = new HttpClient { BaseAddress = new Uri(baseAddress)};
        }

        protected async Task<T> GetJsonAsync<T>(BaseRequest request)
        {
            var response = await httpClient.GetAsync(request.ToString()).ConfigureAwait(false);
            
            KunaApiException.CheckException(response); 
            //response.EnsureSuccessStatusCode();         // throw if web request failed

            var json = await response.Content.ReadAsStringAsync();
            
            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }

        protected async Task<T> PostJsonAsync<T>(BaseRequest request)
        {
            var response = await httpClient.PostAsync(request.Url,
                new StringContent(request.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded")).ConfigureAwait(false);

            KunaApiException.CheckException(response);
            //response.EnsureSuccessStatusCode();         // throw if web request failed

            var json = await response.Content.ReadAsStringAsync();
            
            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }

        #region Private Methods

        public async Task<Holder> GetHolderInfoAsync() => await GetJsonAsync<Holder>(new RequestHolderInfo(signParams));

        public async Task<List<Order>> GetHolderOrdersAsync(MarketPair pair) => await GetJsonAsync<List<Order>>(new RequestHolderOrders(signParams, pair));

        public async Task<List<Trade>> GetHolderTradesAsync(MarketPair pair) => await GetJsonAsync<List<Trade>>(new RequestHolderTrades(signParams, pair));

        public async Task<Order> PlaceOrderAsync(OrderSide orderSide, decimal volume, MarketPair pair, decimal coinPrice) => await PostJsonAsync<Order>(new RequestPlaceOrder(signParams, orderSide, volume, pair, coinPrice));

        public async Task<Order> CancelOrderAsync(uint orderId) => await PostJsonAsync<Order>(new RequestCancelOrder(signParams, orderId));

        #endregion

        #region Public Methods

        public  async Task<long> GetTimestampAsync() => await GetJsonAsync<long>(new RequestTimestamp());

        public async Task<TickerLine> GetTickerLineAsync(MarketPair pair) => await GetJsonAsync<TickerLine>(new RequestTickerline(pair));

        public async Task<OrderBook> GetOrderBookAsync(MarketPair pair) => await GetJsonAsync<OrderBook>(new RequestOrderbook(pair));

        public async Task<Depth> GetDepthAsync(MarketPair pair) => await GetJsonAsync<Depth>(new RequestDepth(pair));

        public async Task<List<Trade>> GetTradesAsync(MarketPair pair, ushort limit = 1000) => await GetJsonAsync<List<Trade>>(new RequestTrades(pair, limit));

        public async Task<List<List<float>>> GetChartDataAsync(ChartFrame frame, MarketPair pair) => await GetJsonAsync<List<List<float>>>(new RequestChartData(pair, frame));

        #endregion

        public void Dispose() => httpClient.Dispose();
    }
}
