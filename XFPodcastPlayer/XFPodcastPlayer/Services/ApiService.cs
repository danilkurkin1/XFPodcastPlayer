using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using XFPodcastPlayer.ServicesInterfaces;

namespace XFPodcastPlayer.Services
{
    public class ApiService: IApiService
    {
        public async Task<HttpResponseMessage> GetPodcastInfo(string podcastId)
        {
            var uri = new Uri(string.Format(Constants.PodcastLookup, podcastId));
            return await initiateCall(uri);
        }

        public async Task<HttpResponseMessage> SearchPodcast(string searchingParams)
        {
            var uri = new Uri(string.Format(Constants.PodcastSearch, searchingParams));
            return await initiateCall(uri);
        }


        private async Task<HttpResponseMessage> initiateCall(Uri url)
        {
            HttpClient client = new HttpClient();
            client.Timeout = Constants.ServerTimeout;

            return await client.GetAsync(url);
        }


        public async Task<Stream> GetRrsStreamAsync(string url)
        {
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            Stream stream = await client.GetStreamAsync(url);
            return stream;
        }

    }
}
