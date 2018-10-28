using PropertyChanged;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFPodcastPlayer.Models;
using XFPodcastPlayer.Services;
using XFPodcastPlayer.ServicesInterfaces;
using XFPodcastPlayer.Views;

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
