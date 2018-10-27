using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.Implementations;
using XFPodcastPlayer.Models;
using PropertyChanged;
using System.Windows.Input;
using Xamarin.Forms;

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
        private MediaFile CurrentFile { get; set; }

        public MediaService()
        {
            AudioTitle = "";
            StartTime = "";
            EndTime = "";
            CrossMediaManager.Current.PlayingChanged += Current_PlayingChanged;
            CrossMediaManager.Current.StatusChanged += Current_StatusChanged;
        }

        private void Current_StatusChanged(object sender, Plugin.MediaManager.Abstractions.EventArguments.StatusChangedEventArgs e)
        {
            Progress =  100;

        }

        private void Current_PlayingChanged(object sender, Plugin.MediaManager.Abstractions.EventArguments.PlayingChangedEventArgs e)
        {
            StartTime = e.Position.ToString(@"mm\:ss");
            EndTime = e.Duration.ToString(@"mm\:ss");
            Progress = e.Progress / 100;
        }

        public void InitPlay(PodcastPlayItem playItem, string coverImage)
        {
                CurrentFile = new MediaFile(playItem.AudioPath, MediaFileType.Audio);
                IsPlaying = true;
                CrossMediaManager.Current.AudioPlayer.Play(CurrentFile);
                AudioTitle = playItem.Title;
                AudioImage = coverImage;
            
        }


        public ICommand PlayPauseCommand => new Command(() =>
        {
            if (IsPlaying)
            {
                IsPlaying = false;
                CrossMediaManager.Current.AudioPlayer.Pause();
            }
            else
            {
                IsPlaying = true;
                CrossMediaManager.Current.AudioPlayer.Play(CurrentFile);
            }
        });

    
    }
}
