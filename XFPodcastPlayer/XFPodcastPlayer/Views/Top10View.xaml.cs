using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFPodcastPlayer.Models;
using XFPodcastPlayer.ViewModels;

namespace XFPodcastPlayer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Top10View : ContentPage
    {
        public Top10ViewModel vm;
        public Top10View()
        {
            InitializeComponent();
            vm = new Top10ViewModel();
            Title = "Top 10 podcasts";
            vm.Navigation = Navigation;
            BindingContext = vm;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as PodcastTop10;
            if (item == null)
                return;

            vm.OpenPodcastDetailView.Execute(item);

            // Manually deselect item.
            Top10ListView.SelectedItem = null;
        }

        async void OpenSearchView(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchView(new SearchViewModel()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(vm.Top10Items.Count == 0)
            {
                vm.LoadItemsCommand.Execute(null);
            }
                       
        }


    }
}