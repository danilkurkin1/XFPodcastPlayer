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
        PodcastDetailViewModel viewModel;

        public PodcastDetailView(PodcastDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        //public PodcastDetailView()
        //{
        //    InitializeComponent();

        //    //var item = new PodcastPlayItem
        //    //{
        //    //    Text = "Item 1",
        //    //    Description = "This is an item description."
        //    //};

        //    //viewModel = new PodcastDetailViewModel(item);
        //    //BindingContext = viewModel;
        //}
    }
}