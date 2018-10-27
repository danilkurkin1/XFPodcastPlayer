using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XFPodcastPlayer.Models;

namespace XFPodcastPlayer.ServicesInterfaces
{
    public interface IDataService
    {
        List<PodcastTop10> ParseTop10Rrs(Stream rrsStream);
        List<PodcastPlayItem> ParsePodcastPlayList(Stream rrsStream);
        Task<PodcastList> ParsePodcastObject(HttpResponseMessage message);
        string GetPodcastId(string url);
    }
}
