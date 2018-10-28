using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFPodcastPlayer.Models;
using XFPodcastPlayer.ViewModels;

namespace XFPodcastPlayer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchView : ContentPage
    {
        SearchViewModel vm;

        public SearchView(SearchViewModel ViewModel)
        {
            InitializeComponent();
            vm = ViewModel;
            vm.Navigation = Navigation;
            BindingContext = vm;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as PodcastSearchDetail;
            if (item == null)
                return;

            vm.PlaySample.Execute(item);
          
            // Manually deselect item.
            SearchListView.SelectedItem = null;
        }
    }
}