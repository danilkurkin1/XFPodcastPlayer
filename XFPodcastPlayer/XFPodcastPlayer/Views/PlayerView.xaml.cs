using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFPodcastPlayer.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlayerView : ContentView
	{
        public PlayerView ()
		{
            InitializeComponent();
        }

        private void PlayPause_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}