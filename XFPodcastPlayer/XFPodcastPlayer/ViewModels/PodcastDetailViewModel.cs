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
        private int index { get; set; } = 0;

        public PodcastDetailViewModel(PodcastDetail podcastDetail)
        {
            PodcastDetailItem = podcastDetail;
            PlayList = new ObservableCollection<PodcastPlayItem>();
            Task.Run(async () => await GetPlayList(podcastDetail.feedUrl));
        }


        private async Task GetPlayList(string feedUrl)
        {
            try
            {
                await App.PopupService.StartLoading();
                var stream = await ApiService.GetRrsStreamAsync(feedUrl);
                var result = DataService.ParsePodcastPlayList(stream);
                await App.PopupService.StopLoading();
                PlayList.Clear();
                foreach (var r in result)
                {
                    PlayList.Add(r);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

            }

        }

        public void PlayFile(PodcastPlayItem playItem)
        {
            PlayList[index].IsPlaying = false;
            index = PlayList.IndexOf(playItem);
            PlayList[index].IsPlaying = true;

            App.MediaPlayer.InitPlay(playItem, PodcastDetailItem.artworkUrl100);
        }

       
      
    }
}
