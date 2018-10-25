using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace XFPodcastPlayer.ServicesInterfaces
{
    public interface IApiService
    {
        Task<HttpResponseMessage> GetPodcastInfo(string podcastId);
        Task<Stream> GetRrsStreamAsync(string url);
    }
}
