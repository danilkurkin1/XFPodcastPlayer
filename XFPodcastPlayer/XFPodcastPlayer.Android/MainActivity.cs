using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using XFPodcastPlayer.Droid.Services;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace XFPodcastPlayer.Droid
{
    [Activity(Label = "XFPodcastPlayer", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static string AudioPath { get; set; }
        public static string AudioTitle { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            LoadApplication(new App());

            if (Device.Idiom != TargetIdiom.Tablet)
                RequestedOrientation = ScreenOrientation.Portrait;
            else
                RequestedOrientation = ScreenOrientation.Landscape;
        }

        public override void OnBackPressed()
        {
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {
                Task.Run(async ()=> await App.PopupService.StopLoading());
            }
           
        }

    }
}