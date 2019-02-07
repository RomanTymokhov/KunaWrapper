using System.Threading.Tasks;
using System.Collections.Generic;
using KunaWrapper.DataLayer.ReciveData;
using KunaWrapper.DataLayer.RequestData;

namespace KunaWrapper
{
    public sealed class PrivateClient : BaseClient
    {
        public PrivateClient(string apiKey, string apiSec) : base(apiKey, apiSec) { }

        public async Task<Holder> GetHolderInfoAsync() =>
                await GetJsonAsync<Holder>(new RequestHolderInfo(authData));

        public async Task<List<Order>> GetHolderOrdersAsync(string pairId) =>
                await GetJsonAsync<List<Order>>(new RequestHolderOrders(authData, pairId));

        public async Task<List<Trade>> GetHolderTradesAsync(string pairId) =>
                await GetJsonAsync<List<Trade>>(new RequestHolderTrades(authData, pairId));

        public async Task<DepositAddresses> GetDepositAddressesAsync(string currenyId) =>
                await GetJsonAsync<DepositAddresses>(new RequestDepositAddresses(authData, currenyId));

        public async Task<DepositAddress> CreateAddressAsync(string currensyId) =>
                await GetJsonAsync<DepositAddress>(new RequestCreateDepositAddress(authData, currensyId));


        /// <summary>
        /// Place Order
        /// </summary>
        /// <param name="ordeType"> _buy or _sell</param>
        /// <param name="pairId">Currecy pair identifikator</param>
        /// <param name="volume">Base Volume</param>
        /// <param name="price">Base Price</param>
        /// <returns>Order</returns>
        public async Task<Order> PlaceOrderAsync(string ordeType, string pairId, decimal volume, decimal price) =>
                await PostJsonAsync<Order>(new RequestPlaceOrder(authData, ordeType, pairId, volume, price));

        public async Task<Order> CancelOrderAsync(uint orderId) =>
                await PostJsonAsync<Order>(new RequestCancelOrder(authData, orderId));
    }
}
