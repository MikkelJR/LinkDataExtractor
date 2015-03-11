using System.IO;
using System.Net;
using System.Text;

namespace LinkDataExtractor.Library
{
    public static class HttpHandler
    {
        public static string DownloadString(string url, string userAgent)
        {
            var request = (HttpWebRequest) WebRequest.Create(url);

            request.UserAgent = userAgent;

            using (var response = (HttpWebResponse) request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();

                    if (receiveStream == null) return string.Empty;

                    StreamReader readStream = response.CharacterSet == null
                        ? new StreamReader(receiveStream)
                        : new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                    var data = readStream.ReadToEnd();

                    readStream.Close();

                    return data;
                }

                return string.Empty;
            }
        }
    }
}