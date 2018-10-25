using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using XFPodcastPlayer.Models;
using XFPodcastPlayer.ServicesInterfaces;
using XFPodcastPlayer.Views;

namespace XFPodcastPlayer.ViewModels
{
    public class Top10ViewViewModel : BaseViewModel
    {
        public ObservableCollection<PodcastTop10Item> Top10Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private readonly IApiService _apiService;
        private readonly IDataParse _dataParse;

        public Top10ViewViewModel(IApiService apiService, IDataParse dataParse)
        {
            _apiService = apiService;
            _dataParse = dataParse;
            Title = "Top 10 podcast";
            Top10Items = new ObservableCollection<PodcastTop10Item>();
            LoadItemsCommand = new Command(async () =>
            {
                await ExecuteLoadItemsCommand();
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            var stream = await _apiService.GetRrsStreamAsync(Constants.PodcastTop10Url);
            var result = _dataParse.ParseTop10Rrs(stream);
            Top10Items = new ObservableCollection<PodcastTop10Item>(result.Channel.Item);
        }
    }
}