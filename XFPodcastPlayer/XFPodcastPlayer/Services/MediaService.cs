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
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public double Progress { get; set; }
        public bool IsPlaying { get; set; }
      
        public MediaService()
        {
            AudioTitle = "";
            StartTime = "";
            EndTime = "";
        }

       
      

        public void InitPlay(PodcastPlayItem playItem, string coverImage)
        {
            IsPlaying = true;
            DependencyService.Get<IAudioStreamingService>().InitAndPlay(playItem.AudioPath, playItem.Title);
           
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
