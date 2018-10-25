using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace XFPodcastPlayer.ServicesInterfaces
{
    public interface IHttpService
    {
        HttpWebRequest GetWebRequest(string uri);
        HttpClient GetHttpClient(bool autoRedirect = true);
    }
}
