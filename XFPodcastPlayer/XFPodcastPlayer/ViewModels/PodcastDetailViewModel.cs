using System;
using System.Threading.Tasks;
using XFPodcastPlayer.Models;
using XFPodcastPlayer.Services;

namespace XFPodcastPlayer.ViewModels
{
    public class PodcastDetailViewModel : BaseViewModel
    {
        public PodcastDetail Item { get; set; }
        private string _feedUrl { get; set; } 

        public PodcastDetailViewModel(PodcastDetail item = null)
        {
            Title = item.collectionName;
            _feedUrl = item.feedUrl;
            Item = item;

           
           

        }
    }
}
