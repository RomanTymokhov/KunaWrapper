namespace KunaWrapper.DataLayer.RequestData
{
    public sealed class AuthData
    {
        internal string PublicKey { get; private set; }
        internal string SecretKey { get; private set; }

        public AuthData(string pubKey, string secKey)
        {
            PublicKey = pubKey;
            SecretKey = secKey;
        }
    }
}
