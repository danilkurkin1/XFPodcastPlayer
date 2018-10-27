using PropertyChanged;
using System.Windows.Input;
using Xamarin.Forms;
using XFPodcastPlayer.Services;
using XFPodcastPlayer.ServicesInterfaces;

namespace XFPodcastPlayer.ViewModels
{
    public class BaseViewModel
    {
        public INavigation Navigation;
        public  readonly IApiService ApiService;
        public  readonly IDataService DataService;
        public MediaService AudioPlayer { get; set; }

        public BaseViewModel()
        {
            ApiService = new ApiService();
            DataService = new DataService();
            AudioPlayer = App.MediaPlayer;
        }

    }
}
