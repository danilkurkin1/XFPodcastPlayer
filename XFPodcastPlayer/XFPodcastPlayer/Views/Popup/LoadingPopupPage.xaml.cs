using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFPodcastPlayer.Views.Popup
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadingPopupPage : Rg.Plugins.Popup.Pages.PopupPage
    {
		public LoadingPopupPage()
		{
			InitializeComponent ();
		}
	}
}