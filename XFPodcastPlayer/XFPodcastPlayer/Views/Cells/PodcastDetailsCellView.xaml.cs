using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFPodcastPlayer.Views.Cells
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PodcastDetailsCellView : ContentView
	{
		public PodcastDetailsCellView()
		{
			InitializeComponent ();
		}
	}

    public class PodcastDetailsCell : ViewCell
    {
        public PodcastDetailsCell()
        {
            View = new PodcastDetailsCellView();
        }
    }
}