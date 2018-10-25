using System;
using System.Net;
using System.Net.Http;
using Xamarin.Forms;

[assembly: Dependency(typeof(XFPodcastPlayer.Droid.Service.HttpService))]

namespace XFPodcastPlayer.Droid.Service
{
    class HttpService
    {
        public WebResponse GetWebRequest(string uri)
        {
           WebRequest webRequest = WebRequest.Create(uri);
           return webRequest.GetResponse();
           
        }

        public HttpClient GetHttpClient(bool autoRedirect = true)
        {
            return new HttpClient(new Xamarin.Android.Net.AndroidClientHandler() { AllowAutoRedirect = autoRedirect });
        }
    }
}