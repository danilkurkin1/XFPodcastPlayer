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
        Top10ViewModel vm;
        public Top10View()
        {
            InitializeComponent();
            vm = new Top10ViewModel();
            BindingContext = vm;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as PodcastDetail;
            if (item == null)
                return;

            await Navigation.PushAsync(new PodcastDetailView(new PodcastDetailViewModel(item)));

            // Manually deselect item.
            Top10ListView.SelectedItem = null;
        }

        async void OpenSearchView(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SearchView());
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