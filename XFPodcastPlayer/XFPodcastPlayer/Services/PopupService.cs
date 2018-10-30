using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFPodcastPlayer.Views.Popup;

namespace XFPodcastPlayer.Services
{
    public class PopupService
    {
        public async Task StartLoading()
        {
            Device.BeginInvokeOnMainThread(
            async () => {
                await PopupNavigation.Instance.PushAsync(new LoadingPopupPage(), false);
            });     
        }

        public async Task StopLoading()
        {
            Device.BeginInvokeOnMainThread(
            async () => {
                 await PopupNavigation.Instance.PopAllAsync();
            });
        }
    }
}
