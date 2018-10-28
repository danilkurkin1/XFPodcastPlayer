using System.IO;
using System.Net.Http;
using System.Threading.Tasks;


namespace XFPodcastPlayer.ServicesInterfaces
{
    public interface IApiService
    {
        Task<HttpResponseMessage> GetPodcastInfo(string podcastId);
        Task<HttpResponseMessage> SearchPodcast(string keyword);
        Task<Stream> GetRrsStreamAsync(string url);
    }
}
