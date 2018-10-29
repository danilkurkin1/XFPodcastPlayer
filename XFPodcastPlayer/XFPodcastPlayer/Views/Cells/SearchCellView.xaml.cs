using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFPodcastPlayer.Views.Cells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchCellView : ContentView
    {
        public SearchCellView()
        {
            InitializeComponent();
        }
    }

    public class SearchCell : ViewCell
    {
        public SearchCell()
        {
            View = new SearchCellView();
        }
    }
}