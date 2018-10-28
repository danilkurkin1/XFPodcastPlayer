using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using XFPodcastPlayer.Models;
using XFPodcastPlayer.Views;

namespace XFPodcastPlayer.ViewModels
{
   
    public class SearchViewModel : BaseViewModel
    {
        public string SearchRequest { get; set; }
        public ObservableCollection<PodcastSearchDetail> SearchResults { get; set; }
        private int index { get; set; } = 0;

        public SearchViewModel()
        {
            SearchResults = new ObservableCollection<PodcastSearchDetail>();
        }

        public ICommand SearchPodcast => new Command(async () =>
        {
            if(!string.IsNullOrEmpty(SearchRequest))
                await GetPodcasSearchResults();
        });

        public ICommand PlaySample => new Command((podcastSearchDetail) =>
        {
            var selectedObject = (PodcastSearchDetail)podcastSearchDetail;

            SearchResults[index].IsPlaying = false;
            index = SearchResults.IndexOf(selectedObject);
            SearchResults[index].IsPlaying = true;

            App.MediaPlayer.InitPlay(DataService.ConvertSearchToPodcast(selectedObject), selectedObject.artworkUrl100);
        });

        public async Task<PodcastDetail> GetPodcastDetails(string collectionId)
        {
            var httpResponse = await ApiService.GetPodcastInfo(collectionId);
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


        public async Task GetPodcasSearchResults()
        {
            var preSearchString = SearchRequest.Replace(" ", "+");
            var httpResponse = await ApiService.SearchPodcast(preSearchString);
            var resultList = DataService.ParsePodcastSearchObject(httpResponse).Result;

            SearchResults.Clear();

            foreach (var result in resultList.PodcastSearchDetailList)
            {
                SearchResults.Add(result);
            }
        }
    }
}