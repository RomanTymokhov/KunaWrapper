using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace KunaWrapper.DataLayer.RequestData
{
    public class RequestObject
    {
        [JsonProperty(PropertyName = "access_key")]
        public string AccesKey { get; private set; }

        [JsonProperty(PropertyName = "tonce")]
        public string Tonce { get; private set; }

        [JsonProperty(PropertyName = "signature")]
        public string Signature { get; private set; }


        public RequestObject (string pubKey, int tonce)
        {
            AccesKey = pubKey;
            Tonce = tonce.ToString();
        }


        public void GenerateSignature(string method, string uri)
        {
            Signature = CreateSignature(method, uri);
        }

        private string CreateSignature(string method ,string uri)
        {
            var sortetDict = new SortedDictionary<string, string>(SetParam());
            var sortedArgs = BuildPostData(sortetDict, true);
            var msg = method + "|" + uri + "|" + sortedArgs;  // "HTTP-verb|URI|params"
            var key = Encoding.ASCII.GetBytes(AccesKey);
            var msgBytes = Encoding.ASCII.GetBytes(msg);
            using (var hmac = new HMACSHA256(key))
            {
                byte[] hashmessage = hmac.ComputeHash(msgBytes);
                return BitConverter.ToString(hashmessage).Replace("-", string.Empty).ToLower();
            }
        }         

        private static string BuildPostData(IDictionary<string, string> dict, bool escape = true)
        {
            return string.Join("&", dict.Select(kvp =>
                 string.Format("{0}={1}", kvp.Key, escape ? HttpUtility.UrlEncode(kvp.Value) : kvp.Value)));
        }

        private Dictionary<string, string> SetParam()
        {
            return new Dictionary<string, string>
            {
                ["acces_key"] = AccesKey,
                ["tonce"] = Tonce
            };
        }
    }
}
