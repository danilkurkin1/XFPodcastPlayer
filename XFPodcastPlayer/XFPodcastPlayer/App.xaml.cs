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

        private static PopupService _popupService;
        public static PopupService PopupService => _popupService ?? (_popupService = new PopupService());


        public App()
        {
            InitializeComponent();
            MainPage = Device.Idiom == TargetIdiom.Phone ?  new NavigationPage(new Top10View()) : new NavigationPage(new TabletView());
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
