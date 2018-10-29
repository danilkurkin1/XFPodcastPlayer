using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFPodcastPlayer.Views.Cells
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Top10CellView : ContentView
	{
		public Top10CellView ()
		{
			InitializeComponent ();
		}
	}

    public class Top10Cell : ViewCell
    {
        public Top10Cell()
        {
            View = new Top10CellView();
        }
    }
}