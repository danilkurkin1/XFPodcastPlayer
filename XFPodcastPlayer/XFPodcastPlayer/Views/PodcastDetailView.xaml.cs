using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XFPodcastPlayer.Models;
using XFPodcastPlayer.ViewModels;

namespace XFPodcastPlayer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PodcastDetailView : ContentPage
    {
        PodcastDetailViewModel vm;

        public PodcastDetailView(PodcastDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.vm = viewModel;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as PodcastPlayItem;
            if (item == null)
                return;

            vm.PlayFile(item);

            //// Manually deselect item.
            PodcastPlayList.SelectedItem = null;
        }

        public async void PlayPause_Clicked(object sender, EventArgs e)
        {
            vm.AudioPlayer.PlayPause();
        }
    }
}