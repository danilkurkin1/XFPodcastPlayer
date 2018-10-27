using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFPodcastPlayer.Models;
using XFPodcastPlayer.Services;
using XFPodcastPlayer.ServicesInterfaces;
using XFPodcastPlayer.Views;

namespace XFPodcastPlayer.ViewModels
{
    public class Top10ViewModel : BaseViewModel
    {
        public ObservableCollection<PodcastTop10> Top10Items { get; set; }
        public Command LoadItemsCommand { get; set; }
       
       

        public Top10ViewModel()//IApiService apiService, IDataParse dataParse)
        {
          
            //Title = "Top 10 podcast";
            Top10Items = new ObservableCollection<PodcastTop10>();
            LoadItemsCommand = new Command(async () =>
            {
                await Task.Run(async () => await ExecuteLoadItemsCommand());
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            var stream = await ApiService.GetRrsStreamAsync(Constants.PodcastTop10Url);
            var result = DataService.ParseTop10Rrs(stream);

            Top10Items.Clear();
            
            foreach(var r in result)
            {
                Top10Items.Add(r);
            }
         }

        public ICommand OpenPodcastDetailView => new Command(async(selectedPodcast) =>
        {
            var podcastDetails = await GetPodcastDetails((PodcastTop10)selectedPodcast);
            if (podcastDetails != null)
            {
                await Navigation.PushAsync(new PodcastDetailView(new PodcastDetailViewModel(podcastDetails)));
            }
            else
            {
                //error show popup
            }
        });


        public async Task<PodcastDetail> GetPodcastDetails(PodcastTop10 podcastTop10)
        {
            var podcastId = DataService.GetPodcastId(podcastTop10.Link);
            var httpResponse = await ApiService.GetPodcastInfo(podcastId);
            var result = DataService.ParsePodcastObject(httpResponse).Result;
            if (result.PodcastDetailsCount > 0)
            {
                return result.PodcastDetailsList[0];
            }
            else
            {
                return null;
            }
        }
    }
}