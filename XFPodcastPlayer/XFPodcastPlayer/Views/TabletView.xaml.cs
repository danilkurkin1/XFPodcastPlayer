using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFPodcastPlayer.Models;
using XFPodcastPlayer.ViewModels;

namespace XFPodcastPlayer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabletView : MasterDetailPage
    {
        public TabletView()
        {
            InitializeComponent();
            MasterPage.Top10ListView.ItemSelected += ListView_ItemSelected;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as PodcastTop10;
            if (item == null)
                return;
            var podcastDetails = await MasterPage.vm.GetPodcastDetails(item);
            if (podcastDetails != null)
            {
                var page = new PodcastDetailView(new PodcastDetailViewModel(podcastDetails));
                page.Title = item.Title;

                Detail = page;
                IsPresented = false;

                MasterPage.Top10ListView.SelectedItem = null;
            }
        }
    }
}