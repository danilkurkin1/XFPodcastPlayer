using Android.Content;
using Xamarin.Forms;
using XFPodcastPlayer.Droid.ServiceHelper;
using XFPodcastPlayer.Droid.Services;
using XFPodcastPlayer.ServicesInterfaces;

[assembly: Dependency(typeof(AudioServiceHelper))]

namespace XFPodcastPlayer.Droid.ServiceHelper
{
    public class AudioServiceHelper: IAudioStreamingService
    {
        public void InitAndPlay(string AudioPath, string AudioTitle)
        {
            MainActivity.AudioPath = AudioPath;
            MainActivity.AudioTitle = AudioTitle;

            var intent = new Intent(Android.App.Application.Context, typeof(AudioStreamingService));
            intent.SetAction(AudioStreamingService.ActionPlay);
            intent.PutExtra("NewAudio", AudioPath);
            Android.App.Application.Context.StartService(intent);
        }

        public void Play()
        {
            var intent = new Intent(Android.App.Application.Context, typeof(AudioStreamingService));
            intent.SetAction(AudioStreamingService.ActionPlay);
            Android.App.Application.Context.StartService(intent);
        }

        public void Pause()
        {
           
            var intent = new Intent(Android.App.Application.Context, typeof(AudioStreamingService));
            intent.SetAction(AudioStreamingService.ActionPause);
            Android.App.Application.Context.StartService(intent);
        }

    }
}