using System;
using KunaWrapper;
using KunaWrapper.DataLayer.Enums;
using KunaWrapper.DataLayer.RequestData.FrameData;
using static KunaWrapper.DataLayer.Enums.MarketPair;
using static KunaWrapper.DataLayer.Enums.OrderSide;
using static System.Console;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            

            //TestCancelOrder(client, 14557931);
            //TestSetOrder(client, buy, 0.65m, gbguah, 0.33m);
            //TestKunaPersonTrades(client, btcuah);
            //TestKunaPersonOrders(client, xlmuah);
            //TestKunaPerson(client);

            //TestChartData(client, new OneWeekFrame(50), btcuah);
            //TestDepth(client, krbuah);
            //TestOrderBook(client, btcuah);
            //TestTrades(client, dashuah);
            //TestTickerline(client, ethuah);
            //Console.WriteLine("timestamp --> " + client.GetTimestampAsync().Result);
            //client.Dispose();
        }
        private static void TestChartData(KunaClient client, ChartFrame frame, MarketPair pair)
        {
            var chart = client.GetChartDataAsync(frame, pair).Result;

            foreach (var candle in chart)
            {
                WriteLine("Timestamp --> " + candle[0]);
                WriteLine("Open price --> " + candle[1]);
                WriteLine("Max price --> " + candle[2]);
                WriteLine("Min price --> " + candle[3]);
                WriteLine("Close price --> " + candle[4]);
                WriteLine("Volume --> " + candle[5]);
                WriteLine("----------------------------------");
            }
        }

        private static void TestCancelOrder(KunaClient client, uint id)
        {
            var order = client.CancelOrderAsync(id).Result;

            WriteLine("ORDER SUCCESSFUL CACELED: ");
            WriteLine("Order id --> " + order.OrderId);
            WriteLine("Order side --> " + order.OrderSide);
            WriteLine("Order type --> " + order.OrderType);
            WriteLine("Coin price --> " + order.CoinPrice);
            WriteLine("Avg price --> " + order.AveragePrice);
            WriteLine("Order state --> " + order.OrderState);
            WriteLine("Pair --> " + order.MarketPair);
            WriteLine("Created time --> " + order.CreatedTime);
            WriteLine("Base volume --> " + order.BaseVolume);
            WriteLine("Rem volume --> " + order.RemaininVolume);
            WriteLine("Exc volume --> " + order.ExeutedVolume);
            WriteLine("Trades count --> " + order.TradesCount);
        }
        private static void TestSetOrder(KunaClient client, OrderSide orderSide, decimal volume, MarketPair market, decimal coinPrice)
        {
            var order = client.PlaceOrderAsync(orderSide, volume, market,  coinPrice).Result;

            WriteLine("ORDER SUCCESSFUL CREATED: ");
            WriteLine("Order id --> " + order.OrderId);
            WriteLine("Order side --> " + order.OrderSide);
            WriteLine("Order type --> " + order.OrderType);
            WriteLine("Coin price --> " + order.CoinPrice);
            WriteLine("Avg price --> " + order.AveragePrice);
            WriteLine("Order state --> " + order.OrderState);
            WriteLine("Pair --> " + order.MarketPair);
            WriteLine("Created time --> " + order.CreatedTime);
            WriteLine("Base volume --> " + order.BaseVolume);
            WriteLine("Rem volume --> " + order.RemaininVolume);
            WriteLine("Exc volume --> " + order.ExeutedVolume);
            WriteLine("Trades count --> " + order.TradesCount);
        }
        private static void TestKunaPersonTrades(KunaClient client, MarketPair market)
        {
            var trades = client.GetHolderTradesAsync(market).Result;

            foreach (var trade in trades)
            {
                WriteLine("Trade id --> " + trade.TradeId);
                WriteLine("Price --> " + trade.CoinPrice);
                WriteLine("Volume --> " + trade.BaseVolume);
                WriteLine("Founds --> " + trade.RelativeVolume);
                WriteLine("Market --> " + trade.MarketPair);
                WriteLine("Created time --> " + trade.CreatedTime);
                WriteLine("Unix time --> " + trade.GetUnixTime());
                WriteLine("Order side --> " + trade.OrderSide);
                WriteLine("-------------------------------");
            }
        }
        private static void TestKunaPersonOrders(KunaClient client, MarketPair market)
        {
            var orders = client.GetHolderOrdersAsync(market).Result;

            foreach (var order in orders)
            {
                WriteLine("Order id --> " + order.OrderId);
                WriteLine("Order side --> " + order.OrderSide);
                WriteLine("Order type --> " + order.OrderType);
                WriteLine("Coin price --> " + order.CoinPrice);
                WriteLine("Avg price --> " + order.AveragePrice);
                WriteLine("Order state --> " + order.OrderState);
                WriteLine("Pair --> " + order.MarketPair);
                WriteLine("Created time --> " + order.CreatedTime);
                WriteLine("Base volume --> " + order.BaseVolume);
                WriteLine("Rem volume --> " + order.RemaininVolume);
                WriteLine("Exc volume --> " + order.ExeutedVolume);
                WriteLine("Trades count --> " + order.TradesCount);
                WriteLine("--------------------------------------");
            }
        }
        private static void TestKunaPerson(KunaClient client)
        {
            var person = client.GetHolderInfoAsync().Result;

            WriteLine("Email: " + person.Email);
            WriteLine("Is Active: " + person.IsAktivated);
            WriteLine("My assets: ");
            foreach (var asset in person.Assetses)
            {
                WriteLine("Currency: " + asset.Currency);
                WriteLine("Ballance: " + asset.Ballance);
                WriteLine("Locked $: " + asset.LockedSum);
                WriteLine("----------------------------");
            }
        }

        private static void TestDepth(KunaClient client, MarketPair market)
        {
            var depth = client.GetDepthAsync(market).Result;

            WriteLine("Asks: ");
            WriteLine("------------------------------------");
            foreach (var item in depth.Asks)
            {
                WriteLine("[" + item[0] + "] -- [" + item[1] + "]");
            }
            WriteLine("Bidss: ");
            WriteLine("------------------------------------");
            foreach (var item in depth.Bids)
            {
                WriteLine("[" + item[0] + "] -- [" + item[1] + "]");
            }
        }
        private static void TestOrderBook(KunaClient client, MarketPair market)
        {
            var ordrBook = client.GetOrderBookAsync(market).Result;

            WriteLine("Asks: ");
            WriteLine("--------------------------------------");
            foreach (var ask in ordrBook.Asks)
            {
                WriteLine("Order id --> " + ask.OrderId);
                WriteLine("Order side --> " + ask.OrderSide);
                WriteLine("Order type --> " + ask.OrderType);
                WriteLine("Coin price --> " + ask.CoinPrice);
                WriteLine("Avg price --> " + ask.AveragePrice);
                WriteLine("Order state --> " + ask.OrderState);
                WriteLine("Pair --> " + ask.MarketPair);
                WriteLine("Created time --> " + ask.CreatedTime);
                WriteLine("Base volume --> " + ask.BaseVolume);
                WriteLine("Rem volume --> " + ask.RemaininVolume);
                WriteLine("Exc volume --> " + ask.ExeutedVolume);
                WriteLine("Trades count --> " + ask.TradesCount);
                WriteLine("--------------------------------------");
            }

            Console.WriteLine("Bids: ");
            Console.WriteLine("--------------------------------------");
            foreach (var bid in ordrBook.Bids)
            {
                Console.WriteLine("Order id --> " + bid.OrderId);
                Console.WriteLine("Order side --> " + bid.OrderSide);
                Console.WriteLine("Order type --> " + bid.OrderType);
                Console.WriteLine("Coin prie --> " + bid.CoinPrice);
                Console.WriteLine("Avg price --> " + bid.AveragePrice);
                Console.WriteLine("Order state --> " + bid.OrderState);
                Console.WriteLine("Pair --> " + bid.MarketPair);
                Console.WriteLine("Created time --> " + bid.CreatedTime);
                Console.WriteLine("Base volume --> " + bid.BaseVolume);
                Console.WriteLine("Rem volume --> " + bid.RemaininVolume);
                Console.WriteLine("Exc volume --> " + bid.ExeutedVolume);
                Console.WriteLine("Trades count --> " + bid.TradesCount);
                Console.WriteLine("--------------------------------------");
            }
        }
        private static void TestTrades(KunaClient client, MarketPair market)
        {
            var trades = client.GetTradesAsync(market).Result;

            foreach (var trade in trades)
            {
                WriteLine("Trade id --> " + trade.TradeId);
                WriteLine("Price --> " + trade.CoinPrice);
                WriteLine("Volume --> " + trade.BaseVolume);
                WriteLine("Founds --> " + trade.RelativeVolume);
                WriteLine("Market --> " + trade.MarketPair);
                WriteLine("Created time --> " + trade.CreatedTime);
                WriteLine("Unix time --> " + trade.GetUnixTime());
                WriteLine("Order side --> " + trade.OrderSide);
                WriteLine("-------------------------------");
            }
        }
        private static void TestTickerline(KunaClient client, MarketPair market)
        {
            var tickerline = client.GetTickerLineAsync(market).Result;

            WriteLine("Server time --> " + tickerline.ServerTime);
            WriteLine("Buy price --> " + tickerline.ticker.BuyPrice);
            WriteLine("Sell price --> " + tickerline.ticker.SellPrice);
            WriteLine("Low price 24h --> " + tickerline.ticker.MinPricePerDay);
            WriteLine("High price 24h --> " + tickerline.ticker.MaxPricePerDay);
            WriteLine("Last price --> " + tickerline.ticker.LastOperationPrice);
            WriteLine("Coin volume 24h --> " + tickerline.ticker.CoinVolumePerDay);
            WriteLine("Amount volume --> " + tickerline.ticker.AmountVolumePerDay);

        }
    }
}
