using XFPodcastPlayer.Models;
using PropertyChanged;
using System.Windows.Input;
using Xamarin.Forms;
using XFPodcastPlayer.ServicesInterfaces;

namespace XFPodcastPlayer.Services
{
    [AddINotifyPropertyChangedInterface]
    public class MediaService
    {
        public string AudioTitle { get; set; }
        public string AudioImage { get; set; }
        public bool IsPlaying { get; set; }
        public bool ShowPlayer { get; set; }
      
        public MediaService()
        {
            AudioTitle = "";
        }


        public void InitPlay(PodcastPlayItem playItem, string coverImage)
        {
            IsPlaying = true;
            DependencyService.Get<IAudioStreamingService>().InitAndPlay(playItem.AudioPath, playItem.Title);
            ShowPlayer = true;
            AudioTitle = playItem.Title;
            AudioImage = coverImage;
        }


        public ICommand PlayPauseCommand => new Command(() =>
        {
            if (IsPlaying)
            {
                IsPlaying = false;
                DependencyService.Get<IAudioStreamingService>().Pause();
            }
            else
            {
                IsPlaying = true;
                DependencyService.Get<IAudioStreamingService>().Play();
            }
        });

    
    }
}
