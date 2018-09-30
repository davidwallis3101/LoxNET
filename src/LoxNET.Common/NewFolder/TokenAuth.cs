namespace LoxNET.Common.NewFolder
{
    public static class TokenAuth
    {
        public static string parsePublicKey(string content)
        {
            return content.Replace("-----BEGIN CERTIFICATE-----", "").Replace("-----END CERTIFICATE-----", "");
        }
    }
}
