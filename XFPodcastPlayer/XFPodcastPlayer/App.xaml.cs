using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFPodcastPlayer.Services;
using XFPodcastPlayer.ViewModels;
using XFPodcastPlayer.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFPodcastPlayer
{
    public partial class App : Application
    {
        private static MediaService _mediaPlayer;
        public static MediaService MediaPlayer => _mediaPlayer ?? (_mediaPlayer = new MediaService());

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Top10View(new Top10ViewModel()));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
