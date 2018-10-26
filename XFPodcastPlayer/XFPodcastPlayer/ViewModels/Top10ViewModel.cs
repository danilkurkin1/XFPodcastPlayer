
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFPodcastPlayer.Models;
using XFPodcastPlayer.Services;
using XFPodcastPlayer.ServicesInterfaces;


namespace XFPodcastPlayer.ViewModels
{
    public class Top10ViewModel : BaseViewModel
    {
        public ObservableCollection<PodcastTop10> Top10Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private readonly IApiService _apiService;
        private readonly IDataParse _dataParse;
       

        public Top10ViewModel()//IApiService apiService, IDataParse dataParse)
        {
            _apiService = new ApiService(); //apiService;
            _dataParse = new DataParse(); //dataParse;
            Title = "Top 10 podcast";
            Top10Items = new ObservableCollection<PodcastTop10>();
            LoadItemsCommand = new Command(async () =>
            {
                await Task.Run(async () => await ExecuteLoadItemsCommand());
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            var stream = await _apiService.GetRrsStreamAsync(Constants.PodcastTop10Url);
            var result = _dataParse.ParseTop10Rrs(stream);
            foreach(var r in result)
            {
                Top10Items.Add(r);
            }
           // Top10Items = new ObservableCollection<PodcastTop10>(result);
        }
    }
}