using System;
using System.Web;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace KunaWrapper.DataLayer.RequestData
{
    public class RequestObject
    {
        private readonly string secretKey;

        internal Dictionary<string, string> RequestArgs { get; set; }


        public RequestObject(string pubKey, string secretKey, long tonce)
        {
            this.secretKey = secretKey;

            RequestArgs = new Dictionary<string, string>
            {
                ["access_key"] = pubKey,
                ["tonce"] = tonce.ToString()
            };
        }


        public void GenerateRequest(string method, string uri)
        {
            CreateSignature(method, uri);
        }

        private void CreateSignature(string method ,string uri)
        {
            var sortetDict = new SortedDictionary<string, string>(RequestArgs);
            var sortedArgs = BuildPostData(sortetDict);
            var msg = method + "|" + uri + "|" + sortedArgs;  // "HTTP-verb|URI|params"
            var key = Encoding.ASCII.GetBytes(secretKey);
            var msgBytes = Encoding.ASCII.GetBytes(msg);
            using (var hmac = new HMACSHA256(key))
            {
                byte[] hashmessage = hmac.ComputeHash(msgBytes);

                RequestArgs["signature"] = BitConverter.ToString(hashmessage).Replace("-", string.Empty).ToLower();                
            }
        }

        private static string BuildPostData(IDictionary<string, string> dict, bool escape = true)
        {
            return string.Join("&", dict.Select(kvp =>
                 string.Format("{0}={1}", kvp.Key, escape ? HttpUtility.UrlEncode(kvp.Value) : kvp.Value)));
        }

        public override string ToString()
        {
            return BuildPostData(RequestArgs);
        }
    }
}
