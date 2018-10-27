using XFPodcastPlayer.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XFPodcastPlayer.Services;
using System;

namespace XFPodcastPlayer.ViewModels
{
    public class PodcastDetailViewModel : BaseViewModel
    {
        public PodcastDetail PodcastDetailItem { get; set; }
        public ObservableCollection<PodcastPlayItem> PlayList { get; set; }
        public MediaService AudioPlayer { get; set; }

        public PodcastDetailViewModel(PodcastDetail podcastDetail)
        {
            Title = podcastDetail.collectionName;
            PodcastDetailItem = podcastDetail;
            PlayList = new ObservableCollection<PodcastPlayItem>();
            Task.Run(async () => await GetPlayList(podcastDetail.feedUrl));
            AudioPlayer = App.MediaPlayer;
        }


        private async Task GetPlayList(string feedUrl)
        {
            var stream = await ApiService.GetRrsStreamAsync(feedUrl);
            var result = DataService.ParsePodcastPlayList(stream);
            PlayList.Clear();
            foreach (var r in result)
            {
                PlayList.Add(r);
            }
        }

        public void PlayFile(PodcastPlayItem playItem)
        {
            App.MediaPlayer.InitPlay(playItem, PodcastDetailItem.artworkUrl100);
        }

       
      
    }
}
