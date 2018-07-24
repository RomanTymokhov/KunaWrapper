using System;
using System.Collections.Generic;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    public class SignParams
    {
        internal string PublicKey { get; private set; }
        internal string SecretKey { get; private set; }

        public SignParams(string pubKey, string secKey)
        {
            PublicKey = pubKey;
            SecretKey = secKey;
        }

        public string GetTonce() => DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
    }
}
