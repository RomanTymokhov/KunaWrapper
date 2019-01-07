using System;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.Security.Cryptography;
using KunaWrapper.DataLayer.Helper;

namespace KunaWrapper.DataLayer.RequestData
{
    public abstract class BaseRequest
    {
        private readonly string secretKey;

        internal string queryUrl;
        internal SortedDictionary<string, string> arguments;
        internal IFormatProvider culture = CultureInfo.InvariantCulture;

        public BaseRequest() => arguments = new SortedDictionary<string, string>();
        public BaseRequest(AuthData sign) : this()
        {
            secretKey = sign.SecretKey;
            arguments["tonce"] = GetTonce();
            arguments["access_key"] = sign.PublicKey;
        }

        public void GenerateRequest(string httpVerb) => EncryptSignature(Signature(httpVerb));
        public string Url => arguments.Count == 0 ? queryUrl : new StringBuilder(queryUrl).AppendFormat("?{0}", arguments.ToKeyValueString()).ToString();

        private void EncryptSignature(string signature)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
            {
                byte[] hashmessage = hmac.ComputeHash(Encoding.UTF8.GetBytes(signature));

                arguments["signature"] = BitConverter.ToString(hashmessage).Replace("-", string.Empty).ToLower();                
            }
        }

        private string Signature(string httpVerb) => // "HTTP-verb|URI|params"
            new StringBuilder(httpVerb).AppendFormat("|{0}|{1}", queryUrl, arguments.ToKeyValueString()).ToString();

        private string GetTonce() => DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
    }
}
