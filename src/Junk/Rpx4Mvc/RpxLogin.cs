using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace Rpx4Mvc
{
    /// <summary>
    /// RPX Login implementation
    /// </summary>
    public class RpxLogin : IRpxLogin
    {
        /// <summary>
        /// RPX Api Key
        /// </summary>
        protected string apiKey = "";

        /// <summary>
        /// Creates a new RPX Login instance
        /// </summary>
        /// <param name="apiKey">RPX Api Key</param>
        public RpxLogin(string apiKey)
        {
            this.apiKey = apiKey;
        }

        /// <summary>
        /// Get user profile
        /// </summary>
        /// <param name="token">Token from RPX</param>
        /// <returns>User profile</returns>
        public RpxProfile GetProfile(string token)
        {
            // Fetch authentication info from RPX
            Uri url = new Uri(@"https://rpxnow.com/api/v2/auth_info");
            string data = "apiKey=" + apiKey + "&token=" + token;

            // Auth_info request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
            requestWriter.Write(data);
            requestWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            TextReader responseReader = new StreamReader(response.GetResponseStream());
            string responseString = responseReader.ReadToEnd();
            responseReader.Close();

            // De-serialize JSON
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            RpxAuthInfo authInfo = serializer.Deserialize<RpxAuthInfo>(responseString);

            // Ok?
            if (authInfo.Stat != "ok")
            {
                throw new RpxException("RPX login failed");
            }

            return authInfo.Profile;
        }
    }
}
