using System;
using System.Web;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace KunaWrapper.DataLayer.RequestData
{
    public abstract class BaseRequest
    {
        private readonly string secretKey;

        public string Url { get; set; }

        internal Dictionary<string, string> RequestArgs { get; set; }


        public BaseRequest() => RequestArgs = new Dictionary<string, string>();

        public BaseRequest(SignParams sign)
        {
            secretKey = sign.SecretKey;

            RequestArgs = new Dictionary<string, string>
            {
                ["access_key"] = sign.PublicKey,
                ["tonce"] = sign.GetTonce()
            };
        }


        public void GenerateRequest(string method) => CreateSignature(method, Url);

        private void CreateSignature(string method, string uri)
        {
            var sortetDict = new SortedDictionary<string, string>(RequestArgs);
            var sortedArgs = BuildRequestData(sortetDict);
            var msg = method + "|" + uri + "|" + sortedArgs;  // "HTTP-verb|URI|params"
            var key = Encoding.ASCII.GetBytes(secretKey);
            var msgBytes = Encoding.ASCII.GetBytes(msg);
            using (var hmac = new HMACSHA256(key))
            {
                byte[] hashmessage = hmac.ComputeHash(msgBytes);

                RequestArgs["signature"] = BitConverter.ToString(hashmessage).Replace("-", string.Empty).ToLower();                
            }
        }

        internal static string BuildRequestData(IDictionary<string, string> dict, bool escape = true) => string.Join("&", dict.Select(kvp =>
                 string.Format("{0}={1}", kvp.Key, escape ? HttpUtility.UrlEncode(kvp.Value) : kvp.Value)));
    }
}
