using PayPal.Api;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class PayPalConfiguration
    {

        public static APIContext GetAPIContext(string clientId,string clientSecret, string mode)
        {
            var apiContext = new APIContext(GetAccessToken(clientId,clientSecret,mode));
            apiContext.Config = GetConfig(mode);
            return apiContext;
        }

        private static Dictionary<string, string> GetConfig(string mode)
        {
            return new Dictionary<string, string>()
            {
                {"mode",mode }
            };
        }

        private static string GetAccessToken(string clientId, string clientSecret, string mode)
        {
            string accessToken = new OAuthTokenCredential(clientId, clientSecret, new Dictionary<string, string>() {
                {"mode",mode}
            }).GetAccessToken();
            return accessToken;
        }
    }
}