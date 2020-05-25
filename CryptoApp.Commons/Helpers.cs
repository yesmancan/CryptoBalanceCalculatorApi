using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CryptoApp.Commons
{
    public static class Helpers
    {
        private static WebRequest request;
        private static WebResponse response;
        private static Stream dataStream;
        private static StreamReader reader;
        public static async Task<string> CreateWebRequest(string url)
        {
            request = WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Credentials = CredentialCache.DefaultCredentials;

            response = await request.GetResponseAsync();
            dataStream = response.GetResponseStream();
            reader = new StreamReader(dataStream);

            string responseFromServer = await reader.ReadToEndAsync();

            reader.Close();
            reader.Dispose();
            response.Close();
            response.Dispose();

            return responseFromServer;
        }

        public static string JsonToParams(string json)
        {
            JObject jObj = JsonConvert.DeserializeObject<JObject>(json);
            return string.Join("&", jObj.Children().Cast<JProperty>().Select(jp => jp.Name + "=" + HttpUtility.UrlEncode(jp.Value.ToString())));
        }

    }
}
